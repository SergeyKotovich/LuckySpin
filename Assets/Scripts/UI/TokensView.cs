using TMPro;
using UnityEngine;

public class TokensView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countTokens;

    public void UpdateNumberTokens(int numberTokens)
    {
        _countTokens.text = numberTokens.ToString();
    }
}
