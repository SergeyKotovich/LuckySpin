using System;
using UnityEngine;

public class StopLineController : MonoBehaviour
{
    public event Action <AwardsType> OnAwardEarned;
    
    private bool _isOnRay ;
    private Vector3 _offset = new(0, -55, 0);
    private int _lenghtRay = 250;
    
    public void RayActivation(bool stayRotation)
    {
        _isOnRay = stayRotation;
        if (_isOnRay)
        {
            var ray = new Ray(transform.position-_offset, -transform.up*_lenghtRay);
            if (Physics.Raycast(ray,out var hitInfo))
            {
                switch (hitInfo.collider.tag)
                {
                    case GlobalConstants.GOLD_TAG:
                        OnAwardEarned?.Invoke(AwardsType.Gold);
                        break;
                    case GlobalConstants.GEM_TAG:
                        OnAwardEarned?.Invoke(AwardsType.Gem);
                        break;
                    case GlobalConstants.LIVE_TAG:
                        OnAwardEarned?.Invoke(AwardsType.Live);
                        break;
                    case GlobalConstants.SKULL_TAG:
                        OnAwardEarned?.Invoke(AwardsType.Skull);
                        break;
                }
            }
            _isOnRay = false;
        }
    }
}