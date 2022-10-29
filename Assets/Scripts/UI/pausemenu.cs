using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public FirstPersonController fps;
    private bool paused;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(paused)
            {
                fps.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
            }
            else
            {
                fps.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }
            paused = !paused;
        }
    }

    public void Resume()
    {
        fps.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);     
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menus");
    }
}
