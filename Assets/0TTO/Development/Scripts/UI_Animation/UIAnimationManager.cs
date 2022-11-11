/*  
 *  
 *  OTTO_TemplateProject_UIManager&Animations_readMe:
 *  https://docs.google.com/document/d/17Jo8PX4ugHpw6QIDY779Fv-qGyy2ZCwhHVW2cfVGByc/edit?usp=sharing
 *                                                                  Derviþ GÜRLER - Canvas Animation
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using TMPro;

[HelpURL("https://docs.google.com/document/d/17Jo8PX4ugHpw6QIDY779Fv-qGyy2ZCwhHVW2cfVGByc/edit?usp=sharing")]
public class UIAnimationManager : MonoBehaviour
{
    [HideInInspector]
    public bool entryAnimationDontPlay;
    [Header("METHOD")][Space(10)]
    /// <summary>
    /// 'TAP TO START' için ekrana basýldýðý anda çalýþtýracaðýnýz method için oluþturulan event, incrementallar yok olduktan sonra çalýþmaktadýr.
    /// </summary>
    public UnityEvent LevelStartMethod;

    /// <summary>
    /// 'NEXT' butonuna týkladýktan sonra bir sonraki sahnenin açýlmasý için çalýþacak event, WinPaneldeki çýkýþ animasyonlarý bittikten sonra çalýþmaktadýr.
    /// </summary>
    public UnityEvent LevelNextMethod;

    /// <summary>
    /// 'RETRY' butonuna týklandýktan sonra çalýþacak event, sanheninizi yeniden yüklediðiniz method ya da leveli tekrar baþlatmanýza yarayan methodu atýn. FailPaneldeki çýkýþ animasyonlarý bittikten sonra çalýþmaktadýr.
    /// </summary>
    public UnityEvent LevelRetryMethod;
    [Header("Screens")]
    [Space(10)]
    
    public GameObject ExitCanvas;
    public GameObject InGameScreen;
    public GameObject StartScreen;
    public GameObject WinScreen;
    public GameObject FailScreen;
    public TextMeshProUGUI MoneyTextWinPanel;
    public TextMeshProUGUI MoneyTextInGamePanel;
    public TextMeshProUGUI LevelTextInGameScreen;
    /// <summary>
    /// Oyundaki win ya da fail screenlerini açmadan önce ingamescreene animasyon ile çýkýþ yaptýran method.
    /// </summary>
    /// <param name="IsWin">True ise WinScreen açýlýr. False ise FailScreen açýlýr.</param>
    public void LevelWinLoseScreenOpen(bool IsWin)
    {
        if (IsWin)
        {
            InGameScreen.GetComponent<InGameScreenExit>().OpenPanel(WinScreen);
        }
        else
        {
            InGameScreen.GetComponent<InGameScreenExit>().OpenPanel(FailScreen);
        }
    }

    private static UIAnimationManager _instance;
    public static UIAnimationManager Instance
    {
        get
        {
            return _instance;
        }
    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {

            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;

        }
    }
    public void Move(Transform UI_GO, Transform targetPoint, float time, float delay, bool loop, Ease tweenEase)
    {
        Vector3 temp = UI_GO.transform.localPosition;
        UI_GO.transform.DOLocalMove(targetPoint.localPosition, time).SetDelay(delay).SetLoops(loop == true ? -1 : 0, LoopType.Yoyo).SetEase(tweenEase);
    }
    public void Move(Transform UI_GO, Vector3 targetPoint, float time, float delay, bool loop, Ease tweenEase, Vector3 startPos)
    {
        UI_GO.transform.localPosition = startPos;
        Vector3 temp = UI_GO.transform.localPosition;
        UI_GO.transform.DOLocalMove(targetPoint, time).SetDelay(delay).SetLoops(loop == true ? -1 : 0, LoopType.Yoyo).SetEase(tweenEase);
    }

    public void Scale(Transform UI_GO, float startScale, float finishScale, float time, Ease tweenEase, float delay, bool loop, bool activeOnComplete)
    {
        UI_GO.transform.localScale = Vector3.one * startScale;
        UI_GO.transform.DOScale(Vector3.one * finishScale, time).SetEase(tweenEase).SetDelay(delay).SetLoops(loop == true ? -1 : 0, LoopType.Yoyo).OnComplete(() => UI_GO.gameObject.SetActive(activeOnComplete));
    }
    public void Rotate(Transform UI_GO, float time, bool loop, float delay)
    {
        Vector3 rotateVector = new Vector3(0, 0, 360);
        UI_GO.transform.DOLocalRotate(rotateVector, time, RotateMode.WorldAxisAdd).SetRelative(true).SetLoops(loop ? -1 : 0).SetEase(Ease.Linear).SetDelay(delay);
    }
    public void FadeOpaque(Image image, float time, float delay)
    {
        float tempAlpha = image.color.a;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        image.DOFade(tempAlpha, time).SetDelay(delay);
    }
    public void FadeTransparent(Image image, float time, float delay)
    {
        float tempAlpha = 0;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        image.DOFade(0, time).SetDelay(delay);
    }
    public void Fade(TextMeshPro txt, float time, float delay)
    {
        float tempAlpha = txt.color.a;
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0f);
        txt.DOFade(tempAlpha, time).SetDelay(delay);
    }
    public void Fade(TextMeshProUGUI txt, float time, float delay)
    {
        float tempAlpha = txt.color.a;
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0f);
        txt.DOFade(tempAlpha, time).SetDelay(delay);
    }

}
