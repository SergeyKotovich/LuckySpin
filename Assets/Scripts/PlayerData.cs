using System;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field:SerializeField] public int GoldCount { get; private set; }
    [field:SerializeField] public int GemCount { get; private set; }
    [field:SerializeField] public int LivesCount { get; private set; }
    public event Action<int, int, int> OnResourceUpdated;

    public void UpdateAmountResources(int amountGoldWon, int amountGemWon, int amountLiveWon)
    {
        GoldCount += amountGoldWon;
        GemCount += amountGemWon;
        LivesCount += amountLiveWon;
    }
    [UsedImplicitly]
    public void AddResources()
    {
        OnResourceUpdated?.Invoke(GoldCount,GemCount,LivesCount);
    }
    
}
