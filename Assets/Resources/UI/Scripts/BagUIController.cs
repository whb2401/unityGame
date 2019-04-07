using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EndlessChallenges
{
    public class BagUIController : MonoBehaviour
    {
        public GameObject GridPrefab;
        public int GridCount = 10;
        public RectTransform GridRoot;
        public RectTransform Self;
        public RectTransform PopupRoot;
        public UnityEngine.UI.Text PopupText;
        public Drager GridDrager;

        private List<BagGridController> grids = new List<BagGridController>();

        public void Init()
        {
            if(GridPrefab == null)
            {
                return;
            }
            for(int i = 0; i < GridCount; i++)
            {
                var grid = Instantiate(GridPrefab);
                grid.transform.parent = GridRoot;
                var controller = grid.GetComponent<BagGridController>();
                controller.PointDownEvent += GridPointDown;
                controller.PointEnterEvent += GridPointEnter;
                controller.PointExitEvent += GridPointExit;
                controller.PointUpEvent += GridPointUp;
                grids.Add(controller);
            }
        }

        public void AddRes(IResInterface res)
        {
            Debug.Log(grids.Count);
            foreach (var item in grids)
            {
                if (item.ResIsNull())
                {
                    item.SetRes(res);
                    break;
                }
            }
        }

        private void GridPointEnter(object o, BagGridTouchArgs arg)
        {
            GridDrager.GridPointEnter(arg);
            var res = arg.controller.GetRes();
            if (res == null)
            {
                return;
            }
            PopupRoot.gameObject.SetActive(true);
            var rectTS = arg.controller.RectTS;
            PopupRoot.position = rectTS.position + new Vector3(rectTS.rect.width,0,0);
            PopupText.text = arg.controller.GetRes().Info();
        }
        private void GridPointExit(object o, BagGridTouchArgs arg)
        {

            if(PopupRoot != null)
                PopupRoot.gameObject.SetActive(false);
        }
        private void GridPointDown(object o, BagGridTouchArgs arg)
        {
            GridDrager.GridPointDown(arg);
        }
        private void GridPointUp(object o, BagGridTouchArgs arg)
        {
            GridDrager.GridPointUp(arg);
        }
    }
}
