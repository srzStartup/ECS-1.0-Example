using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonMouseDownUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool interactable = true;
    public UnityEvent MouseDown;
    public UnityEvent MouseUp;
    public bool SetEnable;
    public void OnPointerDown(PointerEventData data)
    {
        if (interactable)
        {
            MouseDown.Invoke();
            this.enabled = SetEnable;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (interactable)
        {
            MouseUp.Invoke();
        this.enabled = SetEnable;
        }
    }
}