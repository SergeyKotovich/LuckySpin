using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpinDrumController : MonoBehaviour
{ 
    public event Action <bool> OnRotationFinished;
    
    [SerializeField] private float _maxRotationTime;
    [SerializeField] private float _maxRotationSpeed;
    [SerializeField] private ParticleSystem _particleSystem;
    
    private float _minRotationTime = 1f ;
    private float _minRotationSpeed = 25;
    
    [UsedImplicitly]
    public void RotateDrum()
    {
        _particleSystem.Play();
        StartCoroutine(RotateDrumCoroutine());
        OnRotationFinished?.Invoke(false);
    }

    private IEnumerator RotateDrumCoroutine()
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
        _particleSystem.Stop();
    }
}