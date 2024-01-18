using System;
using JetBrains.Annotations;
using UnityEngine;

public class Award : MonoBehaviour
{
    public event Action OnStartPulseAnimation;
    public event Action OnStartMovementAnimation;
    [field:SerializeField] public AwardParameters AwardParameters { get; private set; }
    
    private Transform _awardRoot;

    [UsedImplicitly]
    public void PlayPulseAnimation()
    {
        OnStartPulseAnimation?.Invoke();
        gameObject.SetActive(false);
        _awardRoot.gameObject.SetActive(false);
    }
    
    [UsedImplicitly]
    public void PlayMovementAnimation()
    {
        OnStartMovementAnimation?.Invoke();
        gameObject.SetActive(false);
        _awardRoot.gameObject.SetActive(false);
    }
    
    public void Initialize(Transform awardRoot)
    {
        _awardRoot = awardRoot;
    }
   
    
}