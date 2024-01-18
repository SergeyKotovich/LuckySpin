using System;
using UnityEngine;

public class StopLineController : MonoBehaviour
{
    public event Action <int> OnAwardEarned;
    
    private bool _isOnRay ;
    private Vector3 _offset = new(0, -55, 0);
    private int _lenghtRay = 250;
    
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
                case GlobalConstants.GOLD_TAG:
                    OnAwardEarned?.Invoke((int)AwardsType.Gold);
                    break;
                case GlobalConstants.GEM_TAG:
                    OnAwardEarned?.Invoke((int)AwardsType.Gem);
                    break;
                case GlobalConstants.LIVE_TAG:
                    OnAwardEarned?.Invoke((int)AwardsType.Live);
                    break;
                case GlobalConstants.SKULL_TAG:
                    OnAwardEarned?.Invoke((int)AwardsType.Skull);
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