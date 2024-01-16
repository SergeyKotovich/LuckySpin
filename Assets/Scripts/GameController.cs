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
    [SerializeField] private SpinButtonController _spinButtonController;


    private void Awake()
    {
        Initialize();

        SetResourcesAmount();

        SubscribeToEvents();
    }

    private void SetResourcesAmount()
    {
        _tokensView.SetTokensAmount(_tokensManager.TokensCount);
        _playerDataView.SetResourcesAmount(_playerData.GoldCount, _playerData.GemCount, _playerData.LivesCount);
    }

    private void Initialize()
    {
        _spinDrumController.Initialize(_tokensManager);
        _chest.Initialize(_tokensManager);
    }

    private void SubscribeToEvents()
    {
        _tokensManager.OnDestroyToken += _tokensView.SetTokensAmount;
        _spinDrumController.OnRotationFinished += _stopLineController.RayActivation;
        _spinDrumController.OnRotationFinished += _spinButtonController.ChangeButtonInteractivity;
        _stopLineController.OnAwardEarned += _awardsController.Initialize;
        _chest.OnResourcesWon += _chestView.UpdateResourcesWonAmount;
        _chest.OnResourcesWon += _playerData.UpdateResourcesAmount;
        _playerData.OnResourceUpdated += _playerDataView.UpdateResourcesAmount;
        _chest.OnPlayAnimation += _spinButtonController.ChangeButtonInteractivity;
    }

    private void OnDestroy()
    {
        _tokensManager.OnDestroyToken -= _tokensView.SetTokensAmount;
        _spinDrumController.OnRotationFinished -= _stopLineController.RayActivation;
        _spinDrumController.OnRotationFinished -= _spinButtonController.ChangeButtonInteractivity;
        _stopLineController.OnAwardEarned -= _awardsController.Initialize;
        _chest.OnResourcesWon -= _chestView.UpdateResourcesWonAmount;
        _chest.OnResourcesWon -= _playerData.UpdateResourcesAmount;
        _playerData.OnResourceUpdated -= _playerDataView.UpdateResourcesAmount;
        _chest.OnPlayAnimation -= _spinButtonController.ChangeButtonInteractivity;
    }
}
