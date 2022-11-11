using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoseScreenEntry : MonoBehaviour
{
    [SerializeField] Transform ImageFailed;
    [SerializeField] Transform btnRetry;
    [SerializeField] Transform btnTarget;


    void Start()
    {
        UIAnimationManager.Instance.FadeOpaque(GetComponent<Image>(), .4f, 0);

        UIAnimationManager.Instance.FadeOpaque(ImageFailed.GetComponent<Image>(), .2f, .4f);
        UIAnimationManager.Instance.Scale(ImageFailed, 0, ImageFailed.localScale.x, .2f, Ease.OutBack, .4f, false, true);

        UIAnimationManager.Instance.Move(btnRetry, btnRetry.localPosition, .2f, .4f, false, Ease.OutBack, btnTarget.localPosition);
        UIAnimationManager.Instance.Scale(btnRetry, 0, btnRetry.localScale.x, .3f, Ease.InSine, .4f, false, true);

    }

}
