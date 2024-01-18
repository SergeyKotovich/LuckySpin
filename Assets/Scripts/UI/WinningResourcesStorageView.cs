using TMPro;
using UnityEngine;

public class WinningResourcesStorageView : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI _amountGoldWon;
    [SerializeField] private TextMeshProUGUI _amountGemWon;
    [SerializeField] private TextMeshProUGUI _amountLiveWon;
    
    public void UpdateResourcesWonAmount(int amountGoldWon, int amountGemWon, int amountLiveWon)
    {
        _amountGoldWon.text = amountGoldWon.ToString();
        _amountGemWon.text = amountGemWon.ToString();
        _amountLiveWon.text = amountLiveWon.ToString();
    }
}