using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TokensManager : MonoBehaviour
{
    [SerializeField] private Animator _tokenPrefab;
    [SerializeField] private Transform _rootToken;
    [SerializeField] private int _countTokens ;

    public event Action<int> OnDestroyToken;
    private static readonly int _spin = Animator.StringToHash("spin");
    
    public void Initialize()
    {
        var token = Instantiate(_tokenPrefab,parent:_rootToken);
        token.SetTrigger(_spin);
    }

    public int GetCountTokens()
    {
        return _countTokens;
    }
    [UsedImplicitly]
    public void DestroyToken()
    {
        _countTokens--;
        OnDestroyToken?.Invoke(_countTokens);
    }
    
    

    

   
}
