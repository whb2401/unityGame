using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessChallenges
{ 
    [RequireComponent(typeof(Camera))]
    public class CameraFollower : MonoBehaviour
    {
        public Transform target;
        public float Distance = 5f;
        public float Speed = 1f;

        public void SetTarget(Transform value)
        {
            target = value;
        }

        private void Update()
        {
            var val = Input.GetAxis("Mouse ScrollWheel");

            Distance = Distance - val;

            if (target != null)
            {
                var forward_w = Vector3.forward;
                var right_w = Vector3.right;
                var up_w = Vector3.up;
                var mixDirection = forward_w + right_w + up_w * 2f;
                var cameraTargetPose = target.position + mixDirection.normalized * Distance;

                transform.position = Vector3.Lerp(transform.position, cameraTargetPose, Speed * Time.deltaTime);
                transform.forward = -(transform.position - target.position).normalized;
            }
        }

    }
}


