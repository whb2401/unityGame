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
                if (result.hitInfo.collider == null)
                {
                    return;
                }
                Vector3 targetPos = Vector3.zero;
                if (result.hitInfo.collider.gameObject.layer == 9)
                {
                    targetPos = result.hitInfo.point;
                }
                else if (result.hitInfo.collider.gameObject.layer == 10)
                {
                    targetPos = result.hitInfo.transform.position;
                }

                MoveCurEffect.Play();
                MoveCurEffect.transform.position = targetPos + new Vector3(0, 0.1f, 0);
            }

        }
    }
}

