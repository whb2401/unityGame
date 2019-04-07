namespace EndlessChallenges
{
    public enum EquipmentType
    {
        Sword,
        Unknow
    }

    public enum WearType
    {
        DoubleHand,
        OneHand,
        Unknow,
    }

    public abstract class Equipment : Res,IEquipment
    {
        public virtual int AttackValue()
        {
            return 0;
        }
        public virtual WearType GetWearType()
        {
            return WearType.Unknow;
        }
    }
}

