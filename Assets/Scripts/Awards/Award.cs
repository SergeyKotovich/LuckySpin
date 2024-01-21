using System;
using JetBrains.Annotations;
using UnityEngine;

public class Award : MonoBehaviour
{
    private Action _onStartPulse;
    private Action _onStartMovement;
    
    [field:SerializeField] public AwardParameters AwardParameters { get; private set; }

    [SerializeField] private ParticleSystem _particleSystem;
    
    private Transform _awardRoot;
    
    [UsedImplicitly]
    public void PlayPulseAnimation()
    {
        _onStartPulse?.Invoke();
        AwardDisable();
    }
    
    [UsedImplicitly]
    public void PlayMovementAnimation()
    {
        _onStartMovement?.Invoke();
        AwardDisable();
    }
    
    private void AwardDisable()
    {
        _particleSystem.Stop();
        gameObject.SetActive(false);
        _awardRoot.gameObject.SetActive(false);
    }
    
    public void Initialize(Transform awardRoot, Action onStartPulse , Action onStartMovement )
    {
        _onStartMovement = onStartMovement;
        _onStartPulse = onStartPulse;
        _awardRoot = awardRoot;
    }
    
    [UsedImplicitly]
    public void Play()
    {
        _particleSystem.Play();
    }
   
    
}