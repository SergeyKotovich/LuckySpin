using UnityEngine;

public class AwardsController : MonoBehaviour
{
   [SerializeField] private Award [] _allAwardsPrefabs;
   [SerializeField] private Transform _awardRoot;
   [SerializeField] private Chest _chest;
   
   private Award _award;
   
   public void Initialize(int award)
   {
      _awardRoot.gameObject.SetActive(true);
      _award = Instantiate(_allAwardsPrefabs[award], parent: _awardRoot);
      _award.Initialize(_chest,_awardRoot);
      _award.Initialize(_chest,_awardRoot);
      switch (_award.AwardParameters.Award)
      {
         case Awards.Gold:
            _chest.AddResources(_award.AwardParameters.AwardsCount, 0, 0);
            break;
         case Awards.Gem:
            _chest.AddResources(0, _award.AwardParameters.AwardsCount, 0);
            break;
         case Awards.Live:
            _chest.AddResources(0, 0, _award.AwardParameters.AwardsCount);
            break;
         case Awards.Skull:
            break;
      }
   }
}
