using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    [SerializeField] KeyCode pausemenuKey;
    bool pauseMenuopen = false;


    public GameObject pausepanel;



    


    public void Pause()
    {   
        pausepanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void Mainmenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }



    private void Update()
    {
        if (Input.GetKeyDown(pausemenuKey) && pauseMenuopen == false)
        {
            Pause();
            pauseMenuopen = true;
        }

        
        else if (Input.GetKeyDown(pausemenuKey) && pauseMenuopen == true)
        {
            Resume();
            pauseMenuopen = false;
        }
        


    }




}
