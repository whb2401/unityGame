using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessChallenges
{
    public class TouchEffect : MonoBehaviour
    {
        public ParticleSystem MoveCurEffect;

        private void Start()
        {
        }

        public void SetEffectPoseWithTouch(object o, TouchCotroller.TouchResult result)
        {
            if (result != null)
            {
                if (result.hitInfo.collider == null || result.hitInfo.collider.gameObject.layer != 9)
                {
                    return;
                }
                var targetPos = result.hitInfo.point;
                MoveCurEffect.Play();
                MoveCurEffect.transform.position = targetPos + new Vector3(0, 0.1f, 0);
            }

        }
    }
}

