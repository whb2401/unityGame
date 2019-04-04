using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace EndlessChallenges
{
    public class TouchCotroller : MonoBehaviour
    {
        public class TouchResult : EventArgs
        {
            public Vector2 firstTouchScreenPos;

            public RaycastHit hitInfo;
        }

        public enum TouchType
        {
            MouseDown,
            TouchDown
        }

        public EventHandler<TouchResult> TouchEvent;

        private void Start()
        {
            
        }
        void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_LINUX
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("mouse left button down");
            }

            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("mouse right button down");
                var mousePosition = Input.mousePosition;
                var ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit Hit;
                Physics.Raycast(ray, out Hit);
                if (TouchEvent != null)
                {
                    var touchResult = new TouchResult();
                    touchResult.firstTouchScreenPos = mousePosition;
                    touchResult.hitInfo = Hit;
                    TouchEvent(this, touchResult);
                }
            }
#endif
        }
    }
}

