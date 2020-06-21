using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
   public string mainMenuScene;
   public GameObject pauseMenu;
   
   public bool isPaused;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        	
        	
            if(isPaused)
        	{
        		ResumeGame();
            }else
            {
            	
            	isPaused=true;
            	pauseMenu.SetActive(true);
            	Time.timeScale=0f;
            	

            }
    }
}
     void ResumeGame()
    {
        isPaused=false;
        pauseMenu.SetActive(false);
        Time.timeScale=1f;
        
    }
     void ReturnToMain()
    {
      Time.timeScale=1f;
      SceneManager.LoadScene(mainMenuScene);
    }
     void QuitGame()
    {
    	Application.Quit();
    }
}
