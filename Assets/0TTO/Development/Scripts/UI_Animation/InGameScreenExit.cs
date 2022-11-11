using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScreenExit : MonoBehaviour
{
    [SerializeField] Transform ImageLevel;
    [SerializeField] Transform imageTarget;
    [SerializeField] Transform MoneyImage;
    [SerializeField] Transform moneyTarget;
    public void OpenPanel(GameObject panel)
    {
        UIAnimationManager.Instance.Move(ImageLevel, imageTarget, .2f, 0, false, Ease.Linear);
        UIAnimationManager.Instance.Move(MoneyImage, moneyTarget, .2f, 0, false, Ease.Linear);
        panel.SetActive(true);
    }

}
