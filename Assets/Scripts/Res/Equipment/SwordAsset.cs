using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessChallenges;
[CreateAssetMenu()]
public class SwordAsset : ScriptableObject
{
    public int maxAttackValue = 0;
    public int minAttackValue = 0;
    public int Id = 0;
    [SerializeField]
    [TextArea(5, 10)]
    public string info;
    public string name;
    
    public WearType wearType = WearType.Unknow;
    public EquipmentType equipmentType = EquipmentType.Unknow;
    public ResType resType;
    public int price;
    public Sprite sprite;
    public GameObject prefab;
}
