using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class InGameScreenEntry : MonoBehaviour
{
    [SerializeField] Transform ImageLevel;
    [SerializeField] Transform imageTarget;
    [SerializeField] Transform MoneyImage;
    [SerializeField] Transform moneyTarget;
    void Start()
    {
        UIAnimationManager.Instance.Move(ImageLevel, ImageLevel.localPosition, .4f, .2f, false, Ease.OutBounce, imageTarget.localPosition);
        UIAnimationManager.Instance.Move(MoneyImage, MoneyImage.localPosition, .4f, .2f, false, Ease.OutBounce, moneyTarget.localPosition);
       
    }
    
}
