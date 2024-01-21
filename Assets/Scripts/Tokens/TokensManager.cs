using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TokensManager : MonoBehaviour
{
    public event Action<int> OnDestroyToken;
    private Action _onPlaySound;
    
    [SerializeField] private Animator _tokenPrefab;
    [SerializeField] private Transform _tokenRoot;
    [field:SerializeField] public int TokensCount { get; private set; } 
    
    private static readonly int _spin = Animator.StringToHash("spin");
    
    

    public void Initialize(Action onPlaySound)
    {
        _onPlaySound = onPlaySound;
    }
    
    
    [UsedImplicitly]
    public void UseToken()
    {
        var token = Instantiate(_tokenPrefab,parent:_tokenRoot);
        token.SetTrigger(_spin);
        TokensCount--;
        OnDestroyToken?.Invoke(TokensCount);
        _onPlaySound?.Invoke();
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