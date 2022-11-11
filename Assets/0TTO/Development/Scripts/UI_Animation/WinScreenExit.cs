using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WinScreenExit : MonoBehaviour
{
    [SerializeField] Transform ImageLight;
    [SerializeField] Transform ImageComplete;
    [SerializeField] Transform btnNext;
    [SerializeField] Transform MoneyImageText;
    [SerializeField] Transform btnTarget;

    public void btnNextClick()
    {
        StartCoroutine(Animasyon());
    }
    IEnumerator Animasyon()
    {
        UIAnimationManager.Instance.FadeTransparent(ImageComplete.GetComponent<Image>(), .4f, 0);
        UIAnimationManager.Instance.Scale(ImageComplete, ImageComplete.localScale.x, 0, .2f, Ease.OutBack, 0f, false, false);

        UIAnimationManager.Instance.FadeTransparent(ImageLight.GetComponent<Image>(), .3f, .2f);

        UIAnimationManager.Instance.Move(btnNext, btnTarget, .2f, 0f, false, Ease.InBack);
        UIAnimationManager.Instance.Scale(btnNext, btnNext.localScale.x, 0, .3f, Ease.OutSine, 0f, false, true);

        UIAnimationManager.Instance.Scale(MoneyImageText, MoneyImageText.localScale.x, 0, .3f, Ease.Linear, .2f, false, false);
        UIAnimationManager.Instance.Move(MoneyImageText, btnTarget, .4f, .2f, false, Ease.InBack);

        yield return new WaitForSeconds(.5f);
        UIAnimationManager.Instance.ExitCanvas.SetActive(true);
        UIAnimationManager.Instance.ExitCanvas.GetComponentInChildren<SceneAlternateExit>().ExitAnimation(false);
    }
}
