using TMPro;
using UnityEngine;

public class TokensView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countTokens;

    public void SetTokensAmount(int numberTokens)
    {
        _countTokens.text = numberTokens.ToString();
    }
}
