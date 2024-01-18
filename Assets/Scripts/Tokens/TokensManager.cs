using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TokensManager : MonoBehaviour
{
    public event Action<int> OnDestroyToken;
    
    [SerializeField] private Animator _tokenPrefab;
    [SerializeField] private Transform _tokenRoot;
    [field:SerializeField] public int TokensCount { get; private set; } 
    
    private static readonly int _spin = Animator.StringToHash("spin");
    
    [UsedImplicitly]
    public void UseToken()
    {
        var token = Instantiate(_tokenPrefab,parent:_tokenRoot);
        token.SetTrigger(_spin);
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