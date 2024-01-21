using System;
using System.Collections.Generic;
using UnityEngine;

public class AwardsController : MonoBehaviour
{
    private Action _onPlayWinSound;
    private Action _onPlayDefeatSound;
    
    [SerializeField] private Award [] _allAwardsPrefabs;
    [SerializeField] private Transform _awardRoot;
    [SerializeField] private WinningResourcesStorage _winningResourcesStorage;
    [SerializeField] private ChestAnimationController _chestAnimationController;
    
    private Award _award;
    
    public void Initialize(Action onPlayWinSound, Action OnPlayDefeatSound)
    {
        _onPlayWinSound = onPlayWinSound;
        _onPlayDefeatSound = OnPlayDefeatSound;
    }
    
    public void SpawnAward(AwardsType award)
    {
        _awardRoot.gameObject.SetActive(true);
        _award = Instantiate(_allAwardsPrefabs[(int)award], parent: _awardRoot);
        
        InitializeAward();
    }

    private void InitializeAward()
    {
        _award.Initialize(_awardRoot, _chestAnimationController.StartPulseAnimation , _chestAnimationController.StartMovementAnimation);
        
        switch (_award.AwardParameters.AwardType)
        {
            case AwardsType.Gold:
                _onPlayWinSound?.Invoke();
                _winningResourcesStorage.AddResources(_award.AwardParameters.AwardsCount, 0, 0);
                break;
            case AwardsType.Gem:
                _onPlayWinSound?.Invoke();
                _winningResourcesStorage.AddResources(0, _award.AwardParameters.AwardsCount, 0);
                break;
            case AwardsType.Live:
                _onPlayWinSound?.Invoke();
                _winningResourcesStorage.AddResources(0, 0, _award.AwardParameters.AwardsCount);
                break;
            case AwardsType.Skull:
                _onPlayDefeatSound?.Invoke();
                break;
        }
    }

   
}