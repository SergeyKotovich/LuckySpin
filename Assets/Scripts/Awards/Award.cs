using System;
using JetBrains.Annotations;
using UnityEngine;

public class Award : MonoBehaviour
{
    public event Action OnStartPulseAnimation;
    public event Action OnStartMovementAnimation;
    [field:SerializeField] public AwardParameters AwardParameters { get; private set; }

    [SerializeField] private ParticleSystem _particleSystem;
    
    private Transform _awardRoot;

    [UsedImplicitly]
    public void PlayPulseAnimation()
    {
        OnStartPulseAnimation?.Invoke();
        AwardDisable();
    }
    
    [UsedImplicitly]
    public void PlayMovementAnimation()
    {
        OnStartMovementAnimation?.Invoke();
        AwardDisable();
    }
    
    private void AwardDisable()
    {
        _particleSystem.Stop();
        gameObject.SetActive(false);
        _awardRoot.gameObject.SetActive(false);
    }
    
    public void Initialize(Transform awardRoot)
    {
        _awardRoot = awardRoot;
    }
    
    [UsedImplicitly]
    public void Play()
    {
        _particleSystem.Play();
    }
   
    
}