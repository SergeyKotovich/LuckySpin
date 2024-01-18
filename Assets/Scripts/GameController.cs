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
    [SerializeField] private ChestAnimationController chestAnimationController;
    [SerializeField] private WinningResourcesStorageView winningResourcesStorageView;
    [SerializeField] private SpinButtonController _spinButtonController;
    [SerializeField] private WinningResourcesStorage _winningResourcesStorage;


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
        chestAnimationController.Initialize(_tokensManager);
    }

    private void SubscribeToEvents()
    {
        _tokensManager.OnDestroyToken += _tokensView.SetTokensAmount;
        _spinDrumController.OnRotationFinished += _stopLineController.RayActivation;
        _spinDrumController.OnRotationFinished += _spinButtonController.ChangeButtonInteractivity;
        _stopLineController.OnAwardEarned += _awardsController.SpawnAward;
        _winningResourcesStorage.OnResourcesWon += winningResourcesStorageView.UpdateResourcesWonAmount;
        _winningResourcesStorage.OnResourcesWon += _playerData.UpdateResourcesAmount;
        _playerData.OnResourceUpdated += _playerDataView.UpdateResourcesAmount;
        chestAnimationController.PlayAnimationFinished += _spinButtonController.ChangeButtonInteractivity;
    }

    private void OnDestroy()
    {
        _tokensManager.OnDestroyToken -= _tokensView.SetTokensAmount;
        _spinDrumController.OnRotationFinished -= _stopLineController.RayActivation;
        _spinDrumController.OnRotationFinished -= _spinButtonController.ChangeButtonInteractivity;
        _stopLineController.OnAwardEarned -= _awardsController.SpawnAward;
        _winningResourcesStorage.OnResourcesWon -= winningResourcesStorageView.UpdateResourcesWonAmount;
        _winningResourcesStorage.OnResourcesWon -= _playerData.UpdateResourcesAmount;
        _playerData.OnResourceUpdated -= _playerDataView.UpdateResourcesAmount;
        chestAnimationController.PlayAnimationFinished -= _spinButtonController.ChangeButtonInteractivity;
    }
}
