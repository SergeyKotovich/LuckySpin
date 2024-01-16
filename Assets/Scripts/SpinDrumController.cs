using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpinDrumController : MonoBehaviour
{ 
     
    [SerializeField] private float _maxRotationTime;
    [SerializeField] private float _maxRotationSpeed;
    [SerializeField] private Button _spinButton;
    public event Action <bool> OnRotationFinished;
    private float _minRotationTime = 1f ;
    private float _minRotationSpeed = 25;
    private TokensManager _tokensManager;

    public void Initialize(TokensManager tokensManager)
    {
        _tokensManager = tokensManager;
    }
    [UsedImplicitly]
    public void RotationDrum()
    {
        StartCoroutine(RotationDrumCoroutine());
        _spinButton.interactable = false;
        OnRotationFinished?.Invoke(false);
    }

    private IEnumerator RotationDrumCoroutine()
    {
        var currentTime = 0f;
        var randomRotationTime = Random.Range(_minRotationTime, _maxRotationTime);
        var randomRotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
        while (currentTime<randomRotationTime)
        {
            transform.Rotate(0,0,randomRotationSpeed*Time.deltaTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
        OnRotationFinished?.Invoke(true);
        _spinButton.interactable = _tokensManager.GetCountTokens()>0;
    }
}