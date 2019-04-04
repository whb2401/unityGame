using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EndlessChallenges
{
    public class MainMeunUIController : MonoBehaviour
    {
        public GameObject Character;
        public GameObject Bag;
        public GameObject System;

        public void ChangeCharacterInterface()
        {
            if (Character != null)
            {
                Character.SetActive(!Character.activeSelf);
            }
        }

        public void ChangeCharacterInterface(bool status)
        {
            if (Character != null)
            {
                Character.SetActive(status);
            }
        }

        public void ChangeBagInterface()
        {
            if (Bag != null)
            {
                Bag.SetActive(!Bag.activeSelf);
            }
        }

        public void ChangeBagInterface(bool status)
        {
            if (Bag != null)
            {
                Bag.SetActive(status);
            }
        }

        public void ChangeSystemInterface()
        {
            if (System != null)
            {
                System.SetActive(!System.activeSelf);
            }
        }

        public void ChangeSystemInterface(bool status)
        {
            if (System != null)
            {
                System.SetActive(status);
            }
        }

    }
}

