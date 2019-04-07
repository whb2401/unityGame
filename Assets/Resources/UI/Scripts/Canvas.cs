using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject Bag;
    public GameObject Character;

    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
}
