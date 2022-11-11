using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/In Game Event Channel")]
public class InGameEventChannel : ScriptableObject
{
    // Game states
    public UnityAction GameStartedEvent;
    public UnityAction LevelStartedEvent;
    public UnityAction LevelAccomplishedEvent;
    public UnityAction LevelFailedEvent;

    public UnityAction NextLevelRequestEvent;

    public UnityAction<int> MoneyUpdatedEvent;

    // Inputs
    public UnityAction MouseDownEvent;

    public void RaiseGameStartedEvent() => GameStartedEvent?.Invoke();

    public void RaiseLevelStartedEvent() => LevelStartedEvent?.Invoke();

    public void RaiseLevelAccomplishedEvent() => LevelAccomplishedEvent?.Invoke();

    public void RaiseLevelFailedEvent() => LevelFailedEvent?.Invoke();

    public void RaiseNextLevelRequestEvent() => NextLevelRequestEvent?.Invoke();

    public void RaiseMoneyUpdatedEvent(int updateAmount) => MoneyUpdatedEvent?.Invoke(updateAmount);

    //public void RaiseIncrementalUpgradeEvent(Incremental incremental)
    //{
    //    IncrementalUpgradeEvent?.Invoke(incremental);
    //}

    //public void RaiseCollectibleTriggerEnterEvent(CollectibleTriggerEnterEventArgs eventArgs)
    //{
    //    CollectibleTriggerEnterEvent?.Invoke(eventArgs);
    //}

    //public void RaiseCollectibleCollectedEvent(CollectibleCollectedEventArgs eventArgs) => CollectibleCollectedEvent?.Invoke(eventArgs);

    public void RaiseMouseDownEvent() => MouseDownEvent?.Invoke();
}

//public class CollectibleCollectedEventArgs : System.EventArgs
//{
//    public Collectible collectible;
//    public Vector3 worldPosition;

//    public CollectibleCollectedEventArgs(Collectible collectible, Vector3 worldPosition)
//    {
//        this.collectible = collectible;
//        this.worldPosition = worldPosition;
//    }
//}

//public class CollectibleTriggerEnterEventArgs : System.EventArgs
//{
//    public Collectible collectible;
//    public HoleController hole;

//    public CollectibleTriggerEnterEventArgs(Collectible collectible, HoleController hole)
//    {
//        this.collectible = collectible;
//        this.hole = hole;
//    }
//}