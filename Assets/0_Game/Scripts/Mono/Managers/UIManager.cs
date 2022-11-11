using System.Collections;
using System.Collections.Generic;

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[DefaultExecutionOrder(-1)]
public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Canvas _canvas;

    [Header("Start Screen")]
    [SerializeField] private RectTransform startScreen;
    [SerializeField] private TextMeshProUGUI startScreen_MoneyText;


    [Space(5)]

    [Header("In-Game Screen")]
    [SerializeField] private RectTransform inGameScreen;
    [SerializeField] private RectTransform inGameScreen_MoneyBG;
    [SerializeField] private TextMeshProUGUI inGameScreen_MoneyText;
    [SerializeField] private TextMeshProUGUI inGameScreen_LevelText;
    [SerializeField] private RectTransform inGameScreen_moneyImageRef;

    [Space(5)]

    //[Header("Win Screen")]
    //[SerializeField] private RectTransform winScreen;
    //[SerializeField] private RectTransform winScreen_MoneyBG;
    //[SerializeField] private TextMeshProUGUI winScreen_MoneyText;
    //[SerializeField] private Image winScreen_LevelEndMoneyImage;
    //[SerializeField] private TextMeshProUGUI winScreen_LevelEndMoneyText;
    //[SerializeField] private RectTransform winScreen_moneyImageRef;
    //[SerializeField] private RectTransform winScreen_LightImage;
    //[SerializeField] private RectTransform[] winScreen_moneyAnimImageRefPoints;
    //[SerializeField] private RectTransform moneyAnimDestinationRefPoint;

    [Space(5)]

    //[Header("Lose Screen")]
    //[SerializeField] private RectTransform loseScreen;
    //[SerializeField] private RectTransform loseScreen_LightImage;

    [Space(5)]

    //[Header("Buttons")]
    //[SerializeField] private Button nextButton;
    //[SerializeField] private Button retryButton;
    //[SerializeField] private Button inGameRetryButton;

    [Header("Anim")]
    [SerializeField] private RectTransform moneyParentHolder;

    [Space(5)]

    [Header("Target Indicators")]
    [SerializeField] private RectTransform targetIndicatorsParent;
    //public List<TargetIndicator> targetIndicators = new List<TargetIndicator>();

    [Space(5)]

    //[Header("Incrementals")]
    //[SerializeField] private List<IncrementalUIController> incrementalUIs;

    [Space(5)]

    [SerializeField] private Transform[] moneyImageAnimRefs;

    [Header("Event Channels")]
    [SerializeField] private InGameEventChannel inGameEventChannel;

    protected override void Awake()
    {
        base.Awake();

        inGameEventChannel.GameStartedEvent += OnGameStarted;
        inGameEventChannel.LevelStartedEvent += OnLevelStarted;
        inGameEventChannel.LevelAccomplishedEvent += OnLevelAccomplished;
        inGameEventChannel.LevelFailedEvent += OnLevelFailed;
        inGameEventChannel.MoneyUpdatedEvent += OnMoneyUpdated;
    }

    void OnDestroy()
    {
        inGameEventChannel.GameStartedEvent -= OnGameStarted;
        inGameEventChannel.LevelStartedEvent -= OnLevelStarted;
        inGameEventChannel.LevelAccomplishedEvent -= OnLevelAccomplished;
        inGameEventChannel.LevelFailedEvent -= OnLevelFailed;
        inGameEventChannel.MoneyUpdatedEvent -= OnMoneyUpdated;
    }

    //Tween tapToStartTween;

    void Start()
    {
        //tapToStartImage.transform.DORewind();
        //tapToStartTween = tapToStartImage.transform.DOPunchScale(Vector3.one * .2f, 2f, elasticity: 0, vibrato: 1)
        //    .SetEase(Ease.Linear)
        //    .SetLoops(-1);

        inGameScreen_LevelText.text = "Level " + GameManager.Instance.level.ToString();

        //for (int i = 0; i < incrementalUIs.Count; i++)
        //{
        //    IncrementalUIController incrementalUI = incrementalUIs[i];
        //    Incremental incremental = GameManager.Instance.incrementals[i];
        //    incrementalUI.Initialize(incremental);
        //    incrementalUI.incrementalButton.onClick.AddListener(() => OnIncrementalClick(incremental, incrementalUI));
        //}
    }

    //private void OnIncrementalClick(Incremental clickedIncremental, IncrementalUIController clickedIncrementalUI)
    //{
    //    int currentMoney = GameManager.Instance.currentMoney;
    //    int upgradePrice = clickedIncremental.CalculateUpgradePrice(clickedIncremental.level + 1);
    //    int nextUpgradePrice = clickedIncremental.CalculateUpgradePrice(clickedIncremental.level + 2);
    //    int clickedIncrementalIndex = incrementalUIs.IndexOf(clickedIncrementalUI);

    //    clickedIncrementalUI.ChangeState(currentMoney - upgradePrice >= nextUpgradePrice);

    //    for (int i = 0; i < incrementalUIs.Count; i++)
    //    {
    //        if (i != clickedIncrementalIndex)
    //        {
    //            IncrementalUIController incrementalUI = incrementalUIs[i];

    //            bool nextState = currentMoney - upgradePrice >= incrementalUI.currentIncremental.CalculateUpgradePrice(incrementalUI.currentIncremental.level + 1);

    //            incrementalUI.ChangeState(nextState);
    //        }
    //    }

    //    GameManager.Instance.UpdateMoney(-upgradePrice);
    //    clickedIncremental.Upgrade();
    //}

    void Update()
    {
        //UpdateTargetIndicators();
    }

    void OnGameStarted()
    {
        //ElephantSDK.Elephant.LevelStarted(currentLevel);
        inGameScreen_MoneyText.text = GameManager.Instance.currentMoney.ToString();
        inGameScreen_LevelText.text = "Level " + GameManager.Instance.level.ToString();
    }

    void OnLevelStarted()
    {
        //inGameScreen_MoneyText.text = Mathf.RoundToInt(GameManager.Instance.currentMoney).ToString();
        inGameScreen_LevelText.text = "Level " + GameManager.Instance.level.ToString();

        //startScreen.gameObject.SetActive(false);
        //inGameScreen.gameObject.SetActive(true);
    }

    void OnLevelAccomplished()
    {
        //winScreen_MoneyText.text = GameManager.Instance.currentMoney.ToString();
        //winScreen_LevelEndMoneyText.text = Mathf.RoundToInt(GameManager.Instance.moneyEarnedInLevel * .5f) + " x " + GameManager.Instance.multiplier;
        //winScreen_LightImage.DORotate(new Vector3(0, 0, 360), 10f, RotateMode.FastBeyond360)
        //    .SetLoops(-1)
        //    .SetEase(Ease.Linear);

        //inGameScreen.gameObject.SetActive(false);
        //winScreen.gameObject.SetActive(true);

        //float firstPartDuration = .5f;
        //float secondPartDuration = .75f;
        //int index = 0;
        //float timePosition = 0f;
        //Sequence sequence = DOTween.Sequence();

        //foreach (RectTransform moneyRefPoint in winScreen_moneyAnimImageRefPoints)
        //{
        //    GameObject moneyImageGO = ObjectPooler.Instance.SpawnFromPool("moneyUI", winScreen_LevelEndMoneyImage.rectTransform.position, Quaternion.identity, false);
        //    RectTransform moneyImageTransform = moneyImageGO.GetComponent<RectTransform>();

        //    moneyImageTransform.localScale = Vector3.one * .512f;

        //    Tween moneyFirstMoveTween = moneyImageTransform.DOMove(moneyRefPoint.position, firstPartDuration);
        //    Tween moneyFirstScaleTween = moneyImageTransform.DOScale(Vector3.one, firstPartDuration).OnStart(() => moneyImageGO.SetActive(true));
        //    Tween moneySecondMoveTween = moneyImageTransform.DOMove(moneyAnimDestinationRefPoint.position, secondPartDuration).SetEase(Ease.InExpo);
        //    Tween moneySecondScaleTween = moneyImageTransform.DOScale(Vector3.one * .9f, secondPartDuration)
        //        .OnComplete(() =>
        //        {
        //            // Taptic.Light();
        //            ObjectPooler.Instance.PushToQueue("moneyUI", moneyImageGO);
        //            winScreen_MoneyBG.DORewind();
        //            winScreen_MoneyBG.DOPunchScale(Vector3.one * .25f, .25f, 1, .1f);
        //        });

        //    timePosition = firstPartDuration * ((float)index++ / winScreen_moneyAnimImageRefPoints.Length);

        //    sequence.Insert(timePosition, moneyFirstMoveTween).Insert(timePosition, moneyFirstScaleTween)
        //        .Insert(timePosition + 1f, moneySecondMoveTween).Insert(timePosition + 1f, moneySecondScaleTween);
        //}
    }

    // ***MARK***
    //private int residualWorth = 0;
    //private const int maxTextCount = 50; 
    //private int currentlyUsedText = 0;
    //private void OnCollectibleCollected(CollectibleCollectedEventArgs eventArgs)
    //{
    //    CollectibleText collectibleTextController = ObjectPooler.Instance.SpawnFromPool(Vector3.zero, Quaternion.identity, false);

    //    if (collectibleTextController && currentlyUsedText < maxTextCount)
    //    {
    //        TextMeshProUGUI collectibleText = collectibleTextController.textMesh;

    //        Vector3 screenPosition = CameraController.Instance.cam.WorldToScreenPoint(eventArgs.position);
    //        collectibleTextController.rectTransform.position = screenPosition;

    //        int worth = residualWorth + eventArgs.worth;
    //        residualWorth = 0;

    //        Color textInitColor = collectibleText.color;
    //        //collectibleText.color = eventArgs.color;
    //        collectibleText.text = "+" + worth.ToString();

    //        currentlyUsedText++;
    //        collectibleTextController.gameObject.SetActive(true);
    //        GameManager.Instance.UpdateMoney(worth);

    //        StartCoroutine(PushCollectibleTextToQueueDelayed(collectibleTextController, textInitColor));
    //    }
    //    else
    //    {
    //        residualWorth += eventArgs.worth;
    //    }
    //}

    //IEnumerator PushCollectibleTextToQueueDelayed(CollectibleText collectibleText, Color textInitColor)
    //{
    //    yield return Utils.GetWaitForSeconds(1f);

    //    collectibleText.gameObject.SetActive(false);
    //    collectibleText.textMesh.color = textInitColor;
    //    ObjectPooler.Instance.PushCollectibleTextToQueue(collectibleText, false);
    //    currentlyUsedText--;
    //}

    //IEnumerator ShowNextButton()
    //{
    //    yield return Utils.GetWaitForSeconds(1f);
    //    nextButton.gameObject.SetActive(true);
    //}

    void OnLevelFailed()
    {
        //inGameScreen.gameObject.SetActive(false);
        //loseScreen.gameObject.SetActive(true);
    }

    Tween _moneyNumaretorTween;
    void OnMoneyUpdated(int updatedAmount)
    {
        Utils.KillTweenIfActive(ref _moneyNumaretorTween);

        _moneyNumaretorTween = DOVirtual.Int(int.Parse(inGameScreen_MoneyText.text), GameManager.Instance.currentMoney, .5f, intValue =>
        {
            inGameScreen_MoneyText.text = intValue.ToString();
            startScreen_MoneyText.text = intValue.ToString();
        }).OnComplete(() => 
        {
            _moneyNumaretorTween = null;

            //int currentMoney = GameManager.Instance.currentMoney;
            //foreach (IncrementalUIController incrementalUI in incrementalUIs)
            //{
            //    bool state = currentMoney >= incrementalUI.currentIncremental.CalculateUpgradePrice(incrementalUI.currentIncremental.level + 1);
            //    incrementalUI.ChangeState(state);
            //}
        });
    }

    //public void PlayMoneyAnim(Vector3 fromScreenPosition)
    //{
    //    GameObject money3dGO = ObjectPooler.Instance.SpawnFromPool("moneyUI3d", Vector3.zero, Quaternion.identity);
    //    RectTransform money3dTransform = money3dGO.GetComponent<RectTransform>();
    //    fromScreenPosition.z = _canvas.planeDistance;
    //    money3dTransform.position = _canvas.worldCamera.ScreenToWorldPoint(fromScreenPosition);
    //    Vector3 initScale = money3dTransform.localScale;
    //    money3dTransform.localScale = Vector3.zero;
    //    money3dTransform.GetChild(0).rotation = Quaternion.Euler(120f, 120, -120f);

    //    float centerOfWidth = Screen.width * .5f;
    //    bool isLeft = fromScreenPosition.x < centerOfWidth;

    //    Vector3 firstPoint = money3dTransform.position + Vector3.one * 5f;
    //    Vector3 secondPoint = firstPoint;
    //    secondPoint.y += 2.5f;
    //    secondPoint.x += (isLeft ? 1 : -1) * 10f;
    //    Vector3 thirdPoint = firstPoint;
    //    thirdPoint.y -= 2.5f;
    //    thirdPoint.x += (isLeft ? 1 : -1) * 10f * 3;

    //    Vector3[] curvePoints = new Vector3[3] { firstPoint, secondPoint, thirdPoint };

    //    float duration = 2f;
    //    float pathDuration = duration * .6f;
    //    float lastMoveDuration = duration * .4f;
    //    Sequence sequence = DOTween.Sequence();

    //    Tween pathTween = money3dTransform.DOPath(curvePoints, pathDuration, PathType.CatmullRom);
    //    Tween scaleTween = money3dTransform.DOScale(initScale, .15f);
    //    Tween rotationYTween = money3dTransform.GetChild(0).DORotate(new Vector3(0f, 360f * 5f, 0f), duration, RotateMode.WorldAxisAdd).SetEase(moneyAnimationCurve);
    //    Vector3 moneyRefPosition = inGameScreen_moneyImageRef.position;
    //    moneyRefPosition.z += 5f;
    //    Tween lastMoveTween = money3dTransform.DOMove(moneyRefPosition, lastMoveDuration);
    //    inGameScreen_MoneyBG.DORewind();
    //    Tween moneyBGPunchScaleTween = inGameScreen_MoneyBG.DOPunchScale(Vector3.one * .1f, .1f);

    //    sequence
    //        .Insert(0f, pathTween)
    //        .Insert(0f, scaleTween)
    //        .Insert(0f, rotationYTween)
    //        .Insert(pathDuration, lastMoveTween)
    //        .Insert(duration, moneyBGPunchScaleTween)
    //        .OnStart(() => money3dGO.SetActive(true))
    //        .OnComplete(() =>
    //        {
    //            ObjectPooler.Instance.PushToQueue("moneyUI3d", money3dGO, false);
    //            money3dTransform.localScale = initScale;
    //            GameManager.Instance.UpdateMoney(5);
    //            //Taptic.Light();
    //        });
    //}



    #region TargetIndicators

    //public TargetIndicator AddTargetIndicator(GameObject target, Color color, Sprite inScreenImage, Sprite offScreenImage)
    //{
    //    Canvas canvas = GetComponent<Canvas>();
    //    //TargetIndicator indicator = Instantiate(targetIndicatorPrefab, canvas.transform);
    //    TargetIndicator indicator = ObjectPooler.Instance.SpawnFromPool("targetIndicator", transform.position, Quaternion.identity, false).GetComponent<TargetIndicator>();
    //    indicator.InitialiseTargetIndicator(target, CameraController.Instance.cam, canvas);
    //    indicator.SetImageAndColors(color, inScreenImage, offScreenImage);
    //    indicator.transform.SetParent(targetIndicatorsParent, false);
    //    indicator.rectTransform.localScale = Vector3.one * .45f;
    //    targetIndicators.Add(indicator);

    //    indicator.gameObject.SetActive(true);

    //    return indicator;
    //}

    //void UpdateTargetIndicators()
    //{
    //    if (targetIndicators.Count > 0)
    //    {
    //        targetIndicators.ForEach(targetIndicator => targetIndicator.UpdateTargetIndicator());
    //    }
    //}

    //public void ChangeIndicatorTarget(TargetIndicator indicator, GameObject target)
    //{
    //    indicator.InitialiseTargetIndicator(target, CameraController.Instance.cam, GetComponent<Canvas>());
    //}

    //public void RemoveTargetIndicator(TargetIndicator indicator)
    //{
    //    indicator.gameObject.SetActive(false);
    //    targetIndicators.Remove(indicator);

    //    ObjectPooler.Instance.PushToQueue("targetIndicator", indicator.gameObject, false);
    //}

    #endregion

    #region Button Clicks

    //public void TapToStartButtonClick()
    //{
    //    //Taptic.Light();

    //    startScreen.gameObject.SetActive(false);
    //    inGameScreen.gameObject.SetActive(true);
    //    //tapToStartTween.Kill();

    //    GameManager.Instance.StartLevel();

    //}

    //public void RetryButtonClick()
    //{
    //    //Taptic.Light();
    //    retryButton.interactable = false;
    //    GameManager.Instance.RestartLevel();
    //}

    //public void NextLevelButtonClick()
    //{
    //    //Taptic.Light();
    //    nextButton.interactable = false;
    //    GameManager.Instance.NextLevel();
    //}

    #endregion

    #region Incrementals

    IEnumerator IncrementalsAnimationCoroutine(params Transform[] boosts)
    {
        yield return new WaitForSeconds(2.0f);

        Sequence sequence = DOTween.Sequence();

        Ease ease = Ease.InOutBounce;
        Vector3 punchScale = Vector3.one * .1f;
        float duration = .5f;
        int vibrato = 1;


        foreach (Transform boost in boosts)
        {
            sequence.Join(boost.DOPunchScale(punchScale, duration, vibrato).SetEase(ease));
        }

        sequence.SetLoops(-1, LoopType.Yoyo);
        sequence.SetDelay(1.5f);
    }

    #endregion
}
