using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

[DefaultExecutionOrder(-5)]
public class GameManager : Singleton<GameManager>
{
    public int level { get; private set; } = 1;
    public bool started { get; private set; }
    public bool ended { get; private set; }
    public bool paused { get; private set; }
    public int currentMoney = 0;
    public int moneyEarnedInLevel = 0;
    public int multiplier = 1;

    [SerializeField] private InGameEventChannel _inGameEventChannel;
    public InGameEventChannel inGameEventChannel => _inGameEventChannel;

    [SerializeField] private List<Incremental> m_Incrementals;
    //public List<Incremental> incrementals => m_Incrementals;

    protected override void Awake()
    {
        _inGameEventChannel.NextLevelRequestEvent += OnNextLevelRequest;
    }

    private void OnDestroy()
    {
        _inGameEventChannel.NextLevelRequestEvent -= OnNextLevelRequest;
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        InputManager.Instance.isActive = false;
        HandleSettings();
        HandleData();
        //Taptic.Heavy();
    }

    private void OnNextLevelRequest()
    {
        InputManager.Instance.isActive = false;

        //Taptic.Light();
        UIAnimationManager.Instance.LevelWinLoseScreenOpen(true);
        //ElephantSDK.Elephant.LevelCompleted(JSONDataManager.Instance.data.inGameLevel);
    }

    void HandleData()
    {
        level = JSONDataManager.Instance.data.inGameLevel;
        currentMoney = JSONDataManager.Instance.data.totalMoney;

        //foreach (IncrementalData incrementalData in JSONDataManager.Instance.data.incrementalDatas)
        //{
        //    Incremental incremental = incrementals.Find(incremental => incremental.type == incrementalData.type);

        //    incremental.level = incrementalData.level;
        //}
    }

    public void StartLevel()
    {
        started = true;
        //ElephantSDK.Elephant.LevelStarted(JSONDataManager.Instance.data.inGameLevel);
        InputManager.Instance.isActive = true;
        _inGameEventChannel.RaiseLevelStartedEvent();
        //Taptic.Light();
    }

    public void NextLevel()
    {
        DOTween.KillAll();

        JSONDataManager.Instance.data.inGameLevel++;

        // Tüm entity leri yok edilir.
        //EntityManager em = World.DefaultGameObjectInjectionWorld.EntityManager;
        //EntityQuery query = em.CreateEntityQuery(ComponentType.ReadWrite<CollectibleComponentData>());
        //em.DestroyEntity(query);

        if (JSONDataManager.Instance.data.inGameLevel >= SceneManager.sceneCountInBuildSettings - 1)
        {
            int selectedLevel = UnityEngine.Random.Range(1, SceneManager.sceneCountInBuildSettings);
            JSONDataManager.Instance.data.realLevel = selectedLevel;

            SceneManager.LoadScene(selectedLevel);
        }
        else
        {
            JSONDataManager.Instance.data.realLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        JSONDataManager.Instance.SaveData();
    }

    public void EndLevel(bool success = true)
    {
        if (ended)
            return;

        ended = true;

        if (success)
        {
            _inGameEventChannel.RaiseLevelAccomplishedEvent();
            //ElephantSDK.Elephant.LevelCompleted(JSONDataManager.Instance.data.inGameLevel);
        }
        else
        {
            _inGameEventChannel.RaiseLevelFailedEvent();
            //ElephantSDK.Elephant.LevelFailed(JSONDataManager.Instance.data.inGameLevel);
        }
    }

    public void RestartLevel()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        paused = true;
    }

    public void Resume()
    {
        paused = false;
    }

    public void UpdateMoney(int amount)
    {
        currentMoney += amount;
        JSONDataManager.Instance.data.totalMoney = currentMoney;
        JSONDataManager.Instance.SaveData();

        if (amount > 0)
        {
            moneyEarnedInLevel += amount;
        }

        _inGameEventChannel.RaiseMoneyUpdatedEvent(amount);
    }

    void OnDisable()
    {
        JSONDataManager.Instance.SaveData();
    }

    private void HandleSettings()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        DOTween.useSafeMode = false;
        DOTween.SetTweensCapacity(500, 125);
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = false;
        Physics.gravity = new Vector3(0f, -500f, 0f);
    }


    // Incremental Handling
    //public void UpgradeIncomeLevel()
    //{
    //    incomeLevel++;
    //    incomePerPunch = settings.GetIncome(incomeLevel);
    //    JSONDataManager.Instance.data.incomeLevel = incomeLevel;
    //    JSONDataManager.Instance.SaveData();
    //}

    //public void UpdateGem(int amount)
    //{
    //    currentGem += amount;
    //    JSONDataManager.Instance.data.totalGem = currentGem;
    //    JSONDataManager.Instance.SaveData();

    //    _inGameEventChannel.RaiseGemUpdatedEvent(amount);
    //}
}
