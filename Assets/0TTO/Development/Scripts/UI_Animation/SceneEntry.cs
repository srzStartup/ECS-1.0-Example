using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneEntry : MonoBehaviour
{
    [SerializeField] Transform[] Image;
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

            foreach (var item in Image)
            {
                item.gameObject.SetActive(true);
            }
            StartCoroutine(Animation());
        }
    }
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(.05f);
        for (int i = 0; i < Image.Length; i++)
        {
            Vector3 tempTarget = new Vector3(Image[i].localPosition.x, Target.localPosition.y, Target.localPosition.z);
            UIAnimationManager.Instance.Move(Image[i],tempTarget , .4f, i * .1f, false, Ease.Linear, Image[i].localPosition);
            //UIAnimationManager.Instance.FadeTransparent(Image[Image.Length - i - 1].GetComponent<Image>(), .05f, i * .05f);
            //UIAnimationManager.Instance.Move(Image[Image.Length-i-1], Target, .05f, i * .05f, false, Ease.Linear);
            //UIAnimationManager.Instance.Scale(Image[Image.Length - i - 1], Image[Image.Length - i - 1].localScale.x, Image[Image.Length - i - 1].localScale.x/2, .1f, Ease.Linear, i * .05f, false, false);
        }
        yield return new WaitForSeconds(.8f);
        UIAnimationManager.Instance.StartScreen.SetActive(true);
        UIAnimationManager.Instance.InGameScreen.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
