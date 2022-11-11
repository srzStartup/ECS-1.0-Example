using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapFeedBack : MonoBehaviour
{
    public GameObject ClickFeedback;

    private void OnInstantiateParticleAnim(GameObject particleTemp)
    {
        UIAnimationManager.Instance.FadeOpaque(particleTemp.GetComponent<Image>(), .4f, 0);
        particleTemp.transform.DOScale(Vector3.one, .4f).SetEase(Ease.Linear).OnComplete(() => Destroy(particleTemp.gameObject));
    }
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 anchorPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponent<RectTransform>(), Input.mousePosition, null, out anchorPos);
            GameObject particleTemp = Instantiate(ClickFeedback, transform.transform);
            particleTemp.GetComponent<RectTransform>().anchoredPosition = anchorPos;
            particleTemp.transform.localScale = Vector3.zero;
            OnInstantiateParticleAnim(particleTemp);

        }
#endif
        foreach (var item in Input.touches)
        {
            if (item.phase == TouchPhase.Began)
            {
                Debug.Log(item.fingerId);
                Vector2 anchorPos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponent<RectTransform>(), item.position, null, out anchorPos);
                GameObject particleTemp = Instantiate(ClickFeedback, transform.transform);
                particleTemp.GetComponent<RectTransform>().anchoredPosition = anchorPos;
                particleTemp.transform.localScale = Vector3.zero;
                OnInstantiateParticleAnim(particleTemp);
                //Taptic.Light();
            }
        }
    }
}
