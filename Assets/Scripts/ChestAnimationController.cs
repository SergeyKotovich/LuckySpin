using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChestAnimationController : MonoBehaviour
{
    public event Action<bool> PlayAnimationFinished; 

    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _rootChest;
    [SerializeField] private ParticleSystem[] _particleSystems;

    private static readonly int _pulse = Animator.StringToHash("pulse");
    private static readonly int _movement = Animator.StringToHash("movement");
    private static readonly int _show = Animator.StringToHash("show");
    
    private TokensManager _tokensManager;
    
    public void Initialize(TokensManager tokensManager)
    {
        _tokensManager = tokensManager;
    }
    
    [UsedImplicitly]
    public void StartPulseAnimation()
    {
        _animator.SetTrigger(_pulse);
        PlayAnimationFinished?.Invoke(false);
    }
    
    [UsedImplicitly]
    public void StartMovementAnimation()
    {
        if (!_tokensManager.HasTokens())
        {
            _rootChest.gameObject.SetActive(true);
            gameObject.transform.SetParent(_rootChest);
            _animator.SetTrigger(_movement);
            PlayAnimationFinished?.Invoke(false);
        }
    }
    
    [UsedImplicitly]
    public void ShowResourceAnimation()
    {
        _animator.SetTrigger(_show);
    }
    
   [UsedImplicitly]
   public void OnSpinButton()
   {
       PlayAnimationFinished?.Invoke(true);
   }

   [UsedImplicitly]
   public void Play()
   {
       for (var i = 0; i < _particleSystems.Length; i++)
       {
           _particleSystems[i].Play();
       }
   }
}