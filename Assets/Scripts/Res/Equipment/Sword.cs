using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessChallenges
{
    public class Sword : Equipment
    {
        private int maxAttackValue = 0;
        private int minAttackValue = 0;
        private string info;
        private string name;
        private WearType wearType = WearType.Unknow;
        private EquipmentType equipmentType = EquipmentType.Unknow;
        private ResType resType;
        private int price;
        private Sprite sprite;
        private GameObject prefab;

        private Sword()
        {
        }

        public static Sword CreateFromAesst(SwordAsset aesst)
        {
            var sword = new Sword();
            sword.minAttackValue = aesst.minAttackValue;
            sword.maxAttackValue = aesst.maxAttackValue;
            sword.info = aesst.info;
            sword.name = aesst.name;
            sword.wearType = aesst.wearType;
            sword.equipmentType = aesst.equipmentType;
            sword.resType = aesst.resType;
            sword.price = aesst.price;
            sword.sprite = aesst.sprite;
            sword.prefab = aesst.prefab;
            return sword;
        }

        //Equipment
        public override int AttackValue()
        {
            if (maxAttackValue > minAttackValue)
            {
                return minAttackValue + (int)(Random.value * (maxAttackValue - minAttackValue));
            }
            return minAttackValue;
        }
        public override WearType GetWearType()
        {
            return wearType;
        }

        //res
        public override string Name()
        {
            return name;
        }

        public override string Info()
        {
            return info;
        }

        public override int Price()
        {
            return price;
        }

        public override Sprite Sprite()
        {
            return sprite;
        }

        public override ResType Type()
        {
            return resType;
        }

        public override GameObject Prefab()
        {
            return prefab;
        }

        public override ResUseReuslt Use(int count)
        {
            return null;
        }
    }
}
