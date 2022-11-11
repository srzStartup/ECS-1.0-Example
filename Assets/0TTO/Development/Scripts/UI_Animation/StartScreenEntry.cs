using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartScreenEntry : MonoBehaviour
{
    [SerializeField] Image tapToStart;
    [SerializeField] Transform incremental;
    [SerializeField] Transform incrementalTarget;
    [SerializeField] Transform startButton;
    void Start()
    {
        UIAnimationManager.Instance.Scale(incremental, 0, 1, 0.4f, Ease.OutBack, 0.1f, false, true);
        UIAnimationManager.Instance.Move(incremental, incremental.localPosition, .4f, .2f, false, Ease.OutBack, incrementalTarget.localPosition);

        UIAnimationManager.Instance.Move(tapToStart.transform, tapToStart.transform.localPosition, .2f, .4f, false, Ease.OutBack, incrementalTarget.localPosition);
        UIAnimationManager.Instance.Scale(startButton,0,1,0.1f,Ease.Flash,.6f,false,true);
        
    }

}
