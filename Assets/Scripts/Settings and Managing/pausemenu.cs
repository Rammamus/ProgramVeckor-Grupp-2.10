using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    bool pauseMenuopen = false;
    public GameObject pausepanel;
    [SerializeField] KeyBindSettings keybindsettings;
    [SerializeField] AudioSource source; 
    [SerializeField] AudioClip sfx;

    public void ButtonSFX()
    {
        source.clip = sfx;
        source.Play();
    }
    public void Pause()
    {
        pausepanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pausepanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        keybindsettings.SaveAndBack();
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    //Togglar pausmenyn om man trycker ned knappen -Filip
    private void Update()
    {
        if (Input.GetKeyDown(KeyBinds.pause) && pauseMenuopen == false)
        {
            Pause();
            pauseMenuopen = true;
        }

        else if (Input.GetKeyDown(KeyBinds.pause) && pauseMenuopen == true)
        {
            Resume();
            pauseMenuopen = false;
        }
    }
}
