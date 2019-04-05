using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessChallenges
{
    public class FirstSceneManager : MonoBehaviour
    {
        public CameraFollower CameraFollower;
        public Challenger Challenger;
        public TouchEffect TouchEffect;
        private List<Challenger> challengers = new List<Challenger>();
        private TouchCotroller touchCotroller;
        void Start()
        {

            CameraFollower.SetTarget(Challenger.transform);
            touchCotroller = new GameObject("touchController").AddComponent<TouchCotroller>();
            touchCotroller.TouchEvent += Challenger.MoveWtihTouch;
            touchCotroller.TouchEvent += TouchEffect.SetEffectPoseWithTouch;
            challengers.Add(Challenger);
        }
    }
}

