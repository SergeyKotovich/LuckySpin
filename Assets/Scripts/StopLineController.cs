using System;
using UnityEngine;

public class StopLineController : MonoBehaviour
{
    private bool _isOnRay ;
    private Vector3 _offset = new(0, -55, 0);
    private int _lenghtRay = 250;
    public event Action <int> OnAwardEarned;

    private void Update()
    {
        if (!_isOnRay)
        {
            return;
        }
        var ray = new Ray(transform.position-_offset, -transform.up*_lenghtRay);
        if (Physics.Raycast(ray,out var hitInfo))
        {
            switch (hitInfo.collider.tag)
            {
                case  GlobalConstants.GOLD_TAG:
                    OnAwardEarned?.Invoke((int)Awards.Gold);
                    break;
                case GlobalConstants.GEM_TAG:
                    OnAwardEarned?.Invoke((int)Awards.Gem);
                    break;
                case GlobalConstants.LIVE_TAG:
                    OnAwardEarned?.Invoke((int)Awards.Live);
                    break;
                case GlobalConstants.SKULL_TAG:
                    OnAwardEarned?.Invoke((int)Awards.Skull);
                    break;
            }
            _isOnRay = false;
        }
    }
    
    public void RayActivation(bool stayRotation)
    {
        _isOnRay = stayRotation;
    }
}