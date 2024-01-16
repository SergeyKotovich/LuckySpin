using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TokensManager : MonoBehaviour
{
    [SerializeField] private Animator _tokenPrefab;
    [SerializeField] private Transform _tokenRoot;
    [field:SerializeField] public int TokensCount { get; private set; } 

    public event Action<int> OnDestroyToken;
    private static readonly int _spin = Animator.StringToHash("spin");
    [UsedImplicitly]
    public void TokenSpawn()
    {
        var token = Instantiate(_tokenPrefab,parent:_tokenRoot);
        token.SetTrigger(_spin);
    }
    [UsedImplicitly]
    public void DestroyToken()
    {
        TokensCount--;
        OnDestroyToken?.Invoke(TokensCount);
    }

    public bool HasTokens()
    {
        if (TokensCount==0)
        {
            return false;
        }

        return true;
    }
    
    

    

   
}