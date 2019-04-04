using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessChallenges
{
    public class FirstSceneManager : MonoBehaviour
    {
        static string CHALLENGERS_RES = "Prefabs/Challenges/Challenges";
        public CameraFollower CameraFollower;
        private List<Challenger> challengers = new List<Challenger>();
        private TouchCotroller touchCotroller;
        private GameObject plane;
        void Start()
        {
            var challenges_obj = Instantiate(Resources.Load<GameObject>(CHALLENGERS_RES));
            if (CameraFollower != null)
            {
                CameraFollower.target = challenges_obj.transform;
            }
            var challenge_com = challenges_obj.GetComponent<Challenger>();

            touchCotroller = new GameObject("touchController").AddComponent<TouchCotroller>();
            touchCotroller.TouchEvent += challenge_com.MoveWtihTouch;

            challengers.Add(challenge_com);
        }
    }
}

