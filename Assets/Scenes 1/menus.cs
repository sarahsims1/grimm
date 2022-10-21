using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Menus
{
    public class menus : MonoBehaviour
    {
        public GameObject mainButtons;
        public GameObject optionsStuff;

        public LevelLoad levelLoad;
        private bool onOptions;

        public void Play()
        {
            levelLoad.Load("Main");
        }
        public void Exit()
        {
            Application.Quit();
        }
        public void Options()
        {
            if (onOptions)
            {
                mainButtons.SetActive(true);
                optionsStuff.SetActive(false);
                onOptions = false;
            }
            else
            {
                mainButtons.SetActive(false);
                optionsStuff.SetActive(true);
                onOptions = true;
            }
        }
        public void AdjustSensitiivty(float newsens)
        {
            FirstPersonController.mouseSensitivity = newsens;
            MouseLook.XSensitivity = newsens;
            MouseLook.YSensitivity = newsens;
        }
    }
}
