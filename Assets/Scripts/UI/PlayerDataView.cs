using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerDataView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldCount;
    [SerializeField] private TextMeshProUGUI _gemCount;
    [SerializeField] private TextMeshProUGUI _liveCount;
    
    private float _amountGoldAfterWinning;
    private float _amountGemAfterWinning;
    private float _amountLivesAfterWinning;
    private float _timeUpdateResources = 3f;
    private float _amountGoldBeforeWinning;
    private float _amountGemBeforeWinning;
    private float _amountLivesBeforeWinning;

    public void SetResourcesAmount(int goldCount,int gemCount, int livesCount)
    {
        _amountGoldBeforeWinning = goldCount;
        _amountGemBeforeWinning = gemCount;
        _amountLivesBeforeWinning = livesCount;
        _goldCount.text = goldCount.ToString();
        _gemCount.text = gemCount.ToString();
        _liveCount.text = livesCount.ToString();
    }

    public void UpdateResourcesAmount(int goldCount, int gemCount, int livesCount)
    {
        _amountGoldAfterWinning = goldCount;
        _amountGemAfterWinning = gemCount;
        _amountLivesAfterWinning = livesCount;
        StartCoroutine(ShowResourcesCalculation());
    }
    
    private IEnumerator ShowResourcesCalculation()
    {
        var currentTime = 0f;
        while (currentTime<_timeUpdateResources)
        {
            _amountGoldBeforeWinning = Mathf.Lerp(_amountGoldBeforeWinning, _amountGoldAfterWinning, currentTime / _timeUpdateResources);
            _amountGemBeforeWinning = Mathf.Lerp(_amountGemBeforeWinning, _amountGemAfterWinning, currentTime / _timeUpdateResources);
            _amountLivesBeforeWinning = Mathf.Lerp(_amountLivesBeforeWinning, _amountLivesAfterWinning, currentTime / _timeUpdateResources);
            currentTime += Time.deltaTime;
            _goldCount.text = _amountGoldBeforeWinning.ToString("0");
            _gemCount.text = _amountGemBeforeWinning.ToString("0");
            _liveCount.text = _amountLivesBeforeWinning.ToString("0");
            yield return null;
        }
    }
}