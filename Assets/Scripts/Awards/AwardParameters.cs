using System;
using UnityEngine;

[Serializable]
public class AwardParameters
{
        [field:SerializeField] public int AwardsCount { get; private set; }
        [field:SerializeField] public Awards Award { get; private set; }
}