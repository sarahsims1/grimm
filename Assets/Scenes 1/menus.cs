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

        public GameObject toggle;
        public GameObject toggleSuper;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            mainButtons.SetActive(true);
            if (staticStuff.endHasBeenGot) toggle.SetActive(true); else toggle.SetActive(false);
            if (staticStuff.twoEndsHaveBeenGot) toggleSuper.SetActive(true); else toggleSuper.SetActive(false);
            optionsStuff.SetActive(false);
        }
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

        public void SprintToggle(bool lightning)
        {
            FirstPersonController.lightningSpeedActive = lightning;
        }

        public void SprintToggleSuper(bool lightning)
        {
            FirstPersonController.superLightningSpeedActive = lightning;
        }
        public void AdjustSensitiivty(float newsens)
        {
            FirstPersonController.mouseSensitivity = newsens;
            MouseLook.XSensitivity = newsens;
            MouseLook.YSensitivity = newsens;
        }
    }
}
