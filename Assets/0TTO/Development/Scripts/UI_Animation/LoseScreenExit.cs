using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoseScreenExit : MonoBehaviour
{
    [SerializeField] Transform ImageFailed;
    [SerializeField] Transform btnRetry;
    [SerializeField] Transform btnTarget;

    public void btnRetryClick()
    {
        StartCoroutine(Animasyon());
    }
    IEnumerator Animasyon()
    {
        UIAnimationManager.Instance.FadeTransparent(ImageFailed.GetComponent<Image>(), .4f, 0f);
        UIAnimationManager.Instance.Scale(ImageFailed, ImageFailed.transform.localScale.x,0, .3f, Ease.Linear, .0f, false, true);

        UIAnimationManager.Instance.Move(btnRetry, btnTarget, .2f, 0f, false, Ease.InBack);
        UIAnimationManager.Instance.Scale(btnRetry, btnRetry.localScale.x,0, .3f, Ease.OutSine, 0f, false, true);
        yield return new WaitForSeconds(.5f);
        UIAnimationManager.Instance.ExitCanvas.SetActive(true);
        UIAnimationManager.Instance.ExitCanvas.GetComponentInChildren<SceneExit>().ExitAnimation(true);
    }
}
