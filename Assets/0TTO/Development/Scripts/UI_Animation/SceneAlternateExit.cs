using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneAlternateExit : MonoBehaviour
{
    [SerializeField] Transform Image;
    [SerializeField] Transform Target;
    public void ExitAnimation(bool fail)
    {
        StartCoroutine(Animation(fail));
    }
    
    IEnumerator Animation(bool fail)
    {
        float _Y=transform.position.y; 
        transform.position=new Vector3(transform.position.x, Target.position.y, transform.position.z);
        yield return new WaitForSeconds(.05f);
        Image.DOMoveY(_Y, .5f).SetEase(Ease.InQuad);
        Image.DOScale(2f, .5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(.5f); 
        Vector3 rotateVec = new Vector3(0, 0, -180);
        Image.DOLocalRotate(rotateVec, .8f,RotateMode.FastBeyond360).SetEase(Ease.OutSine);
        yield return new WaitForSeconds(.3f);
        Image.DOScale(50f, .5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(.5f);
        if (fail)
            UIAnimationManager.Instance.LevelRetryMethod?.Invoke();
        else
            UIAnimationManager.Instance.LevelNextMethod?.Invoke();
    }

}
