namespace EndlessChallenges
{
    public enum ResType
    {
        Unknown,
        Consumables,//消耗品
        Equipment,
        Misc
    }
    
    public abstract class Res : IResInterface
    {
        public virtual string Name()
        {
            return "";
        }
        public virtual string Info()
        {
            return "";
        }

        public virtual ResType Type()
        {
            return ResType.Unknown;
        }

        public virtual int Count()
        {
            return 1;
        }

        public virtual ResUseReuslt Use(int count)
        {
            return null;
        }

        public virtual int Price()
        {
            return 0;
        }
    }
}

