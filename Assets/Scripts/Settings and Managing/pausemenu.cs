using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    // Indicates whether the pause menu is currently open.-william
    bool pauseMenuopen = false;

    // Reference to the pause menu panel GameObject.-william
    public GameObject pausepanel;
    [SerializeField] KeyBindSettings keybindsettings;
    // Reference to the AudioSource component for playing sound effects.-william
    [SerializeField] AudioSource source;

    // AudioClip for the button sound effect.-william
    [SerializeField] AudioClip sfx;

    // Method for playing the button sound effect.-william
    public void ButtonSFX()
    {
        // Set the audio clip and play it.-william
        source.clip = sfx;
        source.Play();
    }
    public void Pause()
    {
        pausepanel.SetActive(true);// Activate the pause menu panel.-william
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;// Stop time to pause the game.-william
        pauseMenuopen = true;   // Update the pause menu status.-william
    }
    public void Resume()
    {
        // Deactivate the pause menu panel.-william

        pausepanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Restore normal time flow.-william

        Time.timeScale = 1;
        keybindsettings.SaveAndBack();
        // Update the pause menu status.-william

        pauseMenuopen = false;
    }
    // Method called to quit the game.-william

    public void quitgame()
    {
        // Quit the application-william

        Application.Quit();
    }
    // Method called to return to the main menu.-william

    public void Mainmenu()
    {
        // Load the main menu scene.-william

        SceneManager.LoadScene(0);
    }

    //Togglar pausmenyn om man trycker ned knappen -Filip
    private void Update()
    {
        if (Input.GetKeyDown(KeyBinds.pause) && pauseMenuopen == false)
        {
            Pause();
        }

        else if (Input.GetKeyDown(KeyBinds.pause) && pauseMenuopen == true)
        {
            Resume();
        }
    }
}
