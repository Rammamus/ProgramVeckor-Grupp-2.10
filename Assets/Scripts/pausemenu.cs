using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject pausepanel;

    public void Pause()
    {   
        pausepanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void meinmenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


}
