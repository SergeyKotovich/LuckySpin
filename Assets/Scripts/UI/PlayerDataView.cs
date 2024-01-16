using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerDataView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldCount;
    [SerializeField] private TextMeshProUGUI _gemCount;
    [SerializeField] private TextMeshProUGUI _liveCount;
    private float _currentAmountGold;
    private float _currentAmountGem;
    private float _currentAmountLives;
    private float _timeUpdateResources = 0.5f;
    private float _amountGoldBeforeWinning;
    private float _amountGemBeforeWinning;
    private float _amountLivesBeforeWinning;

    public void SetResourcesAmount(int goldCount,int gemCount, int liveCount)
    {
        _amountGoldBeforeWinning = goldCount;
        _amountGemBeforeWinning = gemCount;
        _amountLivesBeforeWinning = liveCount;
        _goldCount.text = goldCount.ToString();
        _gemCount.text = gemCount.ToString();
        _liveCount.text = liveCount.ToString();
    }

    public void UpdateResourcesAmount(int amountGold, int amountGem, int amountLives)
    {
        _currentAmountGold = amountGold;
        _currentAmountGem = amountGem;
        _currentAmountLives = amountLives;
        StartCoroutine(ShowResourcesCalculation());
    }
    

    private IEnumerator ShowResourcesCalculation()
    {
        var currentTime = 0f;
        while (currentTime<_timeUpdateResources)
        {
            _amountGoldBeforeWinning = Mathf.Lerp(_amountGoldBeforeWinning, _currentAmountGold, currentTime / _timeUpdateResources);
            _amountGemBeforeWinning = Mathf.Lerp(_amountGemBeforeWinning, _currentAmountGem, currentTime / _timeUpdateResources);
            _amountLivesBeforeWinning = Mathf.Lerp(_amountLivesBeforeWinning, _currentAmountLives, currentTime / _timeUpdateResources);
            currentTime += Time.deltaTime;
            _goldCount.text = _amountGoldBeforeWinning.ToString("0");
            _gemCount.text = _amountGemBeforeWinning.ToString("0");
            _liveCount.text = _amountLivesBeforeWinning.ToString("0");
            yield return null;
        }
    }
}
