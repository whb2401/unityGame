namespace EndlessChallenges
{
    public interface IResInterface
    {
        string Name();
        string Info();
        ResType Type();
        int Count();
        ResUseReuslt Use(int count);
        int Price();
    }
}

