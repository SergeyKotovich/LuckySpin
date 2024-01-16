using JetBrains.Annotations;
using UnityEngine;

public class Award : MonoBehaviour
{
    [field:SerializeField] public AwardParameters AwardParameters { get; private set; }
    private Chest _chest;
    private Transform _awardRoot;

    [UsedImplicitly]
    public void DestroyAward()
    {
        if (gameObject!=null)
        {
            _chest.StartPulsationAnimation();
            Destroy(gameObject);
            _awardRoot.gameObject.SetActive(false);
        }
    }
    
    [UsedImplicitly]
    public void DestroySkull()
    {
        if (gameObject != null)
        {
            _chest.StartMovementAnimation();
            Destroy(gameObject);
            _awardRoot.gameObject.SetActive(false);
        }
    }
    
    public void Initialize(Chest chest, Transform awardRoot)
    {
        _awardRoot = awardRoot;
        _chest = chest;
    }
   
    
}