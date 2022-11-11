using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WinScreenEntry : MonoBehaviour
{
    [SerializeField] Transform ImageLight;
    [SerializeField] Transform ImageComplete;
    [SerializeField] Transform btnNext;
    [SerializeField] Transform MoneyImageText;
    [SerializeField] Transform btnTarget;
    void Start()
    {
        UIAnimationManager.Instance.FadeOpaque(GetComponent<Image>(), .4f,0);

        UIAnimationManager.Instance.FadeOpaque(ImageLight.GetComponent<Image>(), .2f, .4f);
        UIAnimationManager.Instance.Rotate(ImageLight, 2.5f, true, .2f);
        
        UIAnimationManager.Instance.FadeOpaque(ImageComplete.GetComponent<Image>(), .2f, .4f);
        UIAnimationManager.Instance.Scale(ImageComplete, 0, ImageComplete.localScale.x, .2f, Ease.Linear, .4f, false, true);

        UIAnimationManager.Instance.Scale(MoneyImageText, 0, MoneyImageText.localScale.x, 0.4f, Ease.OutBack, .6f, false, true);

        UIAnimationManager.Instance.Move(btnNext, btnNext.localPosition, .4f, .6f, false, Ease.OutBack , btnTarget.localPosition);
        UIAnimationManager.Instance.Scale(btnNext, 0, btnNext.localScale.x, 1f, Ease.InSine, .2f, false, true);
      
    }

}
