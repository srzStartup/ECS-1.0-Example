using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneAlternateEntry : MonoBehaviour
{
    [SerializeField] Transform Image;
    [SerializeField] Transform Target;
    public void Start()
    {
        //PlayerPrefs.SetInt("EntryAnimDontPlay", 1); -->Elephant scriptine
        UIAnimationManager.Instance.entryAnimationDontPlay = PlayerPrefs.GetInt("EntryAnimDontPlay", 1) == 1 ? true : false;
        if (UIAnimationManager.Instance.entryAnimationDontPlay)
        {
            UIAnimationManager.Instance.StartScreen.SetActive(true);
            UIAnimationManager.Instance.InGameScreen.SetActive(true);
            transform.parent.gameObject.SetActive(false);
            PlayerPrefs.SetInt("EntryAnimDontPlay", 0);
        }
        else
        {
            Image.gameObject.SetActive(true);
            StartCoroutine(Animation());
        }
    }
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(.05f);
        Image.DOScale(2f, .5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(.5f);

        Vector3 rotateVec = new Vector3(0, 0, 180);
        Image.DOLocalRotate(rotateVec, .8f,RotateMode.FastBeyond360).SetEase(Ease.OutSine);
        yield return new WaitForSeconds(.3f);
        Image.DOMoveY(Target.position.y, .5f).SetEase(Ease.InQuad);
        Image.DOScale(1f, .5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(.5f);

        UIAnimationManager.Instance.StartScreen.SetActive(true);
        UIAnimationManager.Instance.InGameScreen.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        
    }
}
