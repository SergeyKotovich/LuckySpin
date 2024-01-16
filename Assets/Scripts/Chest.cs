using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public event Action<int, int, int> OnResourcesWon;
    public event Action<bool> OnPlayAnimation; 

    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _rootChest;
    
    private static readonly int _pulse = Animator.StringToHash("pulse");
    private static readonly int _movement = Animator.StringToHash("movement");
    private static readonly int _show = Animator.StringToHash("show");
    
    private TokensManager _tokensManager;
    
    private int _amountGoldWon;
    private int _amountGemWon;
    private int _amountLiveWon;
    
    public void Initialize(TokensManager tokensManager)
    {
        _tokensManager = tokensManager;
    }
    
    public void StartPulsationAnimation()
    {
        _animator.SetTrigger(_pulse);
        OnPlayAnimation?.Invoke(false);
    }
    
    [UsedImplicitly]
    public void StartMovementAnimation()
    {
        if (!_tokensManager.HasTokens())
        {
            OnResourcesWon?.Invoke(_amountGoldWon,_amountGemWon,_amountLiveWon);
            _rootChest.gameObject.SetActive(true);
            gameObject.transform.SetParent(_rootChest);
            _animator.SetTrigger(_movement);
            OnPlayAnimation?.Invoke(false);
        }
    }
    
    [UsedImplicitly]
    public void ShowResourceAnimation()
    {
        _animator.SetTrigger(_show);
    }
    
    public void AddResources(int goldCount, int gemCount, int liveCount)
    {
        _amountGoldWon += goldCount;
        _amountGemWon += gemCount;
        _amountLiveWon += liveCount;
    }
    
   [UsedImplicitly]
   public void OnSpinButton()
   {
       OnPlayAnimation?.Invoke(true);
   }
}