using UnityEngine;
namespace EndlessChallenges
{
    public interface IResInterface
    {
        int Id();
        string Name();
        string Info();
        ResType Type();
        int Count();
        ResUseReuslt Use(int count);
        int Price();
        Sprite Sprite();
        GameObject Prefab();
    }
}

