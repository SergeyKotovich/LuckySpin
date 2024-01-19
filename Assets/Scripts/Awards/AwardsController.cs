using System;
using System.Collections.Generic;
using UnityEngine;

public class AwardsController : MonoBehaviour
{
    [SerializeField] private Award [] _allAwardsPrefabs;
    [SerializeField] private Transform _awardRoot;
    [SerializeField] private WinningResourcesStorage _winningResourcesStorage;
    [SerializeField] private ChestAnimationController _chestAnimationController;

    private Award _award;

    private List<Award> _allAwards = new();

    public void SpawnAward(int award)
    {
        _awardRoot.gameObject.SetActive(true);
        _award = Instantiate(_allAwardsPrefabs[award], parent: _awardRoot);
        _allAwards.Add(_award);
        InitializeAward();
        SubscribeToEvents();
    }

    private void InitializeAward()
    {
        _award.Initialize(_awardRoot);
        
        switch (_award.AwardParameters.AwardType)
        {
            case AwardsType.Gold:
                _winningResourcesStorage.AddResources(_award.AwardParameters.AwardsCount, 0, 0);
                break;
            case AwardsType.Gem:
                _winningResourcesStorage.AddResources(0, _award.AwardParameters.AwardsCount, 0);
                break;
            case AwardsType.Live:
                _winningResourcesStorage.AddResources(0, 0, _award.AwardParameters.AwardsCount);
                break;
            case AwardsType.Skull:
                break;
        }
    }

    private void SubscribeToEvents()
    {
        _award.OnStartPulseAnimation += _chestAnimationController.StartPulseAnimation;
        _award.OnStartMovementAnimation += _chestAnimationController.StartMovementAnimation;
    }

    private void OnDestroy()
    {
        if (_award!=null)
        {
            _award.OnStartPulseAnimation -= _chestAnimationController.StartPulseAnimation;
            _award.OnStartMovementAnimation -= _chestAnimationController.StartMovementAnimation;
        }
        
    }
}