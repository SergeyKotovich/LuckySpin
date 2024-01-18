using System;
using UnityEngine;

[Serializable]
public class AwardParameters
{
        [field:SerializeField] public int AwardsCount { get; private set; }
        [field:SerializeField] public AwardsType AwardType { get; private set; }
}