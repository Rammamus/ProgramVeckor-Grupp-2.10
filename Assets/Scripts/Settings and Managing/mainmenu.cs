using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;

    //Loads the keybind settings and enables the main menu "part" while disabling the options menu "part" - Adrian
    private void Start()
    {
        KeyBinds.Load();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void LoadGame()
    {
        SaveData data = SaveSystem.LoadScene(); //loads the *supposed saved data* - Adrian

        SceneManager.LoadScene(data.scene);
    }

    public void NewGame()
    {
        // Load the first scene (presumably the start of a new game)..-william
        SceneManager.LoadScene(1);
    }

    public void quitgame()
    {
        // Quit the application when called.-william
        Application.Quit();
    }

}
