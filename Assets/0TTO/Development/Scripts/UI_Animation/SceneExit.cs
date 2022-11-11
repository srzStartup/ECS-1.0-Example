using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneExit : MonoBehaviour
{
    [SerializeField] Transform[] Image;
    [SerializeField] Transform Target;
    public void ExitAnimation(bool fail)
    {
        StartCoroutine(Animation(fail));
    }
    
    IEnumerator Animation(bool fail)
    {

        for (int i = 0; i < Image.Length; i++)
        {
            // UIAnimationManager.Instance.Move(Image[i], Image[i].localPosition, .05f, i * .05f, false, Ease.Linear, Target.localPosition);
            //UIAnimationManager.Instance.Scale(Image[i], Image[i].localScale.x / 2, Image[i].localScale.x, .05f, Ease.Linear, i * .05f, false, true);
            //    Vector3 temp = Image[i].localPosition;
            //Image[i].transform.localPosition = Target.localPosition;
            //Image[i].transform.DOLocalMove(temp, .1f).SetEase(Ease.OutSine).SetDelay(i*.1f);
            //UIAnimationManager.Instance.FadeOpaque(Image[i].GetComponent<Image>(), .05f, i * .05f);
            Vector3 tempTarget = new Vector3(Image[i].localPosition.x, Target.localPosition.y, Target.localPosition.z);
            UIAnimationManager.Instance.Move(Image[i], Image[i].localPosition, .4f, i * .1f, false, Ease.Linear, tempTarget);
        }
        yield return new WaitForSeconds(1.3f);
        PlayerPrefs.SetInt("EntryAnimDontPlay", 0);
        if (fail)
            UIAnimationManager.Instance.LevelRetryMethod?.Invoke();
        else
            UIAnimationManager.Instance.LevelNextMethod?.Invoke();
    }

}
