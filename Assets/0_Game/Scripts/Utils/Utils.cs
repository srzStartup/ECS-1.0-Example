using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using Unity.Mathematics;

public static class Utils
{
    private static readonly Dictionary<float, WaitForSeconds> waitMap = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWaitForSeconds(float duration)
    {
        if (waitMap.TryGetValue(duration, out WaitForSeconds waitForSeconds))
        {
            return waitForSeconds;
        }

        waitMap.Add(duration, new WaitForSeconds(duration));

        return waitMap[duration];
    }

    public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element, Camera camera = null)
    {
        camera = camera != null ? camera : Camera.main;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, camera, out Vector3 worldPoint);

        return worldPoint;
    }

    private static PointerEventData _eventDataCurrentPosition;
    private static List<RaycastResult> _raycastResults;

    public static bool IsOverUI()
    {
        _eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        _raycastResults = new List<RaycastResult>();

        EventSystem.current.RaycastAll(_eventDataCurrentPosition, _raycastResults);

        return _raycastResults.Count > 0;
    }

    public static bool IsOverUI(GameObject rectGO)
    {
        _eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        _raycastResults = new List<RaycastResult>();

        EventSystem.current.RaycastAll(_eventDataCurrentPosition, _raycastResults);

        return _raycastResults.Exists(raycastResult => raycastResult.gameObject.Equals(rectGO));
    }

    public static Vector3 WorldToCanvasPosition(this Canvas canvas, Vector3 worldPosition, Camera camera = null)
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
        var viewportPosition = camera.WorldToViewportPoint(worldPosition);
        return canvas.ViewportToCanvasPosition(viewportPosition);
    }

    public static Vector3 ScreenToCanvasPosition(this Canvas canvas, Vector3 screenPosition)
    {
        Vector3 viewportPosition = new Vector3(screenPosition.x / Screen.width,
                                           screenPosition.y / Screen.height,
                                           0);
        return canvas.ViewportToCanvasPosition(viewportPosition);
    }

    public static Vector3 ViewportToCanvasPosition(this Canvas canvas, Vector3 viewportPosition)
    {
        Vector3 centerBasedViewPortPosition = viewportPosition - new Vector3(0.5f, 0.5f, 0);
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector2 scale = canvasRect.sizeDelta;
        return Vector3.Scale(centerBasedViewPortPosition, scale);
    }

    public static void WithPeriod(ref float nextTransactionTime, ref float transactionStartTime, float transactionPeriod, System.Action action)
    {
        if (nextTransactionTime <= transactionStartTime)
        {
            nextTransactionTime += transactionPeriod;

            action.Invoke();
        }

        transactionStartTime += Time.deltaTime;
    }

    public static void WithCooldown(float cooldown, ref float elapsedTime, System.Action action)
    {
        if (elapsedTime >= cooldown)
        {
            action?.Invoke();
            elapsedTime = 0;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public static void WithCooldownPassOneParam<T>(float cooldown, ref float elapsedTime, T obj, System.Action<T> action)
    {
        if (elapsedTime >= cooldown)
        {
            action?.Invoke(obj);
            elapsedTime = 0;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public static void WithCooldownPassTwoParam<T, K>(float cooldown, ref float elapsedTime, T obj1, K obj2, System.Action<T, K> action)
    {
        if (elapsedTime >= cooldown)
        {
            action?.Invoke(obj1, obj2);
            elapsedTime = 0;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public static IEnumerator PushObjectToPool(string tag, GameObject gameObject, float delay)
    {
        yield return GetWaitForSeconds(delay);

        ObjectPooler.Instance.PushToQueue(tag, gameObject);
    }

    public static void KillTweenIfActive<T>(ref T tween, bool nullify = true) where T : Tween
    {
        if (tween != null && tween.IsActive())
        {
            tween.Kill();
            if (nullify) tween = null;
        }
    }

    public static void StopCoroutineIfActive(this MonoBehaviour mono, ref Coroutine coroutine, bool nullify = true)
    {
        if (coroutine != null)
        {
            mono.StopCoroutine(coroutine);
            if (nullify) coroutine = null;
        }
    }

    public static float3 TransformPoint(this float4x4 transform, float3 point)
    {
        return math.transform(transform, point);
    }

    public static float3 InverseTransformPoint(this float4x4 transform, float3 point)
    {
        return math.transform(math.inverse(transform), point);
    }
}