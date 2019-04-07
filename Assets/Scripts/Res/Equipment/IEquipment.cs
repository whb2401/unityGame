using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessChallenges
{
    public interface IEquipment
    {
        int AttackValue();
        WearType GetWearType();
    }
}
