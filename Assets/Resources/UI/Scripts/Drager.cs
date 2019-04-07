using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EndlessChallenges;
public class Drager : MonoBehaviour
{

    public Image DummyImage;
    public RectTransform DummyRectTS;

    private BagGridController controller;
    public void GridPointDown(BagGridTouchArgs arg)
    {
        DummyImage.gameObject.SetActive(true);
        controller = arg.controller;
        if (!controller.ResIsNull())
        {
            DummyImage.sprite = controller.GetRes().Sprite();
            DummyImage.color = Color.white;
        }
        else
        {
            DummyImage.color = Color.clear;
        }
        var mousePos = Input.mousePosition;
    }

    private float swapTime = 0.1f;
    private float recordTime;
    public void GridPointUp(BagGridTouchArgs arg)
    {
        if (controller != arg.controller)
        {
            BagGridController.Swap(controller, arg.controller);
        }
        DummyImage.sprite = null;
        DummyImage.gameObject.SetActive(false);
        recordTime = Time.time;
    }

    public void GridPointEnter(BagGridTouchArgs arg)
    {
        var diffTime = Time.time - recordTime;
        if (diffTime < swapTime)
        {
            if (controller != arg.controller)
            {
                BagGridController.Swap(controller, arg.controller);
            }
        }
    }

    void Update()
    {
        var mousePose = Input.mousePosition;
        transform.position = mousePose;
    }
}

