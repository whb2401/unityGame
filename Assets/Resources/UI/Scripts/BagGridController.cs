using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace EndlessChallenges
{
    public class BagGridTouchArgs : System.EventArgs
    {
        public BagGridController controller;
    }

    public class BagGridController : MonoBehaviour
    {
        public Image Sprite;
        public RectTransform RectTS;
        public System.EventHandler<BagGridTouchArgs> PointDownEvent;
        public System.EventHandler<BagGridTouchArgs> PointUpEvent;
        public System.EventHandler<BagGridTouchArgs> PointEnterEvent;
        public System.EventHandler<BagGridTouchArgs> PointExitEvent;
        public Sprite defualtSprite;
        public bool ResIsNull()
        {
            return res == null ? true : false;
        }

        private IResInterface res;


        public static void Swap(BagGridController left, BagGridController right)
        {
            var res = right.res;
            var color = right.Sprite.color;
            right.SetRes(left.res);
            left.SetRes(res);
            Debug.Log("swap");
        }

        public void Start()
        {
        }

        public void PointDown()
        {
            Debug.Log("point down");
            if (PointDownEvent != null)
            {
                BagGridTouchArgs arg = new BagGridTouchArgs();
                arg.controller = this;
                PointDownEvent(this,arg);
            }
            if(res != null)
                ImageAlpha_50();
        }

        public void PointUp()
        {
            Debug.Log("point up");
            if (PointUpEvent != null)
            {
                BagGridTouchArgs arg = new BagGridTouchArgs();
                arg.controller = this;
                PointUpEvent(this, arg);
            }
            ImageRest();
        }

        public void PointEnter()
        {
            Debug.Log("point enter");
            if (PointEnterEvent != null)
            {
                BagGridTouchArgs arg = new BagGridTouchArgs();
                arg.controller = this;
                PointEnterEvent(this, arg);
            }
        }

        public void PointExit()
        {
            Debug.Log("point exit");
            if (PointExitEvent != null)
            {
                BagGridTouchArgs arg = new BagGridTouchArgs();
                arg.controller = this;
                PointExitEvent(this, arg);
            }
        }
        
        public void ImageAlpha_50()
        {
            Sprite.color = Sprite.color / 2;
        }

        public void ImageRest()
        {
            Sprite.color = Color.white;
        }

        public void SetRes(IResInterface res)
        {
            this.res = res;
            if (res != null)
            {
                Sprite.sprite = res.Sprite();
            }
            else
            {
                Sprite.sprite = defualtSprite;
            }
        }

        public IResInterface GetRes()
        {
            return res;
        }

        public void ClearRes()
        {
            this.res = null;
            Sprite.sprite = null;
            Sprite.sprite = defualtSprite;
        }

        private void Update()
        {
        }
    }
}