using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TokensManager _tokensManager;
    [SerializeField] private TokensView _tokensView;
    [SerializeField] private SpinDrumController _spinDrumController;
    [SerializeField] private StopLineController _stopLineController;
    [SerializeField] private AwardsController _awardsController;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private PlayerDataView _playerDataView;
    [SerializeField] private Chest _chest;
    [SerializeField] private ChestView _chestView;


    private void Awake()
    {
        _spinDrumController.Initialize(_tokensManager);
        _chest.Initialize(_tokensManager);
        var countTokens = _tokensManager.GetCountTokens();
        _tokensView.UpdateNumberTokens(countTokens);
        _playerDataView.SetAmountResources(_playerData.GoldCount,_playerData.GemCount,_playerData.LivesCount);
        _tokensManager.OnDestroyToken += _tokensView.UpdateNumberTokens;
        _spinDrumController.OnRotationFinished += _stopLineController.ActivationRay;
        _stopLineController.OnAwardEarned += _awardsController.InitializeAward;
        _chest.OnResourcesWon += _chestView.UpdateAmountResourcesWon;
        _chest.OnResourcesWon += _playerData.UpdateAmountResources;
        _playerData.OnResourceUpdated += _playerDataView.UpdateAmountResources;
    }

    private void OnDestroy()
    {
        _tokensManager.OnDestroyToken -= _tokensView.UpdateNumberTokens;
        _spinDrumController.OnRotationFinished -= _stopLineController.ActivationRay;
        _stopLineController.OnAwardEarned -= _awardsController.InitializeAward;
        _chest.OnResourcesWon -= _chestView.UpdateAmountResourcesWon;
        _playerData.OnResourceUpdated -= _playerDataView.UpdateAmountResources;
    }
}
