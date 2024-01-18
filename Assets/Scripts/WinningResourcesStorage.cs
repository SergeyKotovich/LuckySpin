using System;
using JetBrains.Annotations;
using UnityEngine;

public class WinningResourcesStorage : MonoBehaviour
{
    public event Action<int, int, int> OnResourcesWon;
    
    private int _amountGoldWon;
    private int _amountGemWon;
    private int _amountLiveWon;
    
    public void AddResources(int goldCount, int gemCount, int liveCount)
    {
        _amountGoldWon += goldCount;
        _amountGemWon += gemCount;
        _amountLiveWon += liveCount;
    }
    
    [UsedImplicitly]
    public void AddResourcesToPlayer()
    {
        OnResourcesWon?.Invoke(_amountGoldWon,_amountGemWon,_amountLiveWon);
    }
}
