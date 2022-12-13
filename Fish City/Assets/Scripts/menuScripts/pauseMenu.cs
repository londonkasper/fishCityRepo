//using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class pauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    void Update(){
        if(PlayerController.GetInstance().GetClickPressed()){
            if(gameIsPaused){
                Resume();
            }
            else{
                PauseGame();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;

    }
    public void PauseGame(){
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
    }

    public void LoadMainMenu(){
       // PlayerController.GetInstance().RegisterClickPressed();   
        SceneManager.LoadScene(0);
    }
    // public void QuitGame(){

    // }
    // public static bool isPaused = false;
    // public GameObject PauseMenuCanvas;
    // //public Button pauseButton;
    // public GameObject pauseButton;
    // public GameObject quitGameButton;
    // public GameObject resumeGameButton;

    // // Start is called before the first frame update
    // void Start()
    // {
 
    // if(!isPaused){
    // Debug.Log("Is Paused: " + isPaused); //This should never say TRUE

    // }
    // Debug.Log("Pause button active: " + pauseButton.activeSelf);
    // Debug.Log("Resume button active: " + resumeGameButton.activeInHierarchy);
    // Debug.Log("Quit button active: " + quitGameButton.activeInHierarchy);

    // }


    // void Update()
    // {
    //     if(PlayerController.GetInstance().GetClickPressed()){

    //     }
    // }
    // public void showPauseMenu(){
    //     Debug.Log("clicked");
    //     PauseMenuCanvas.SetActive(true);
  
    //     isPaused = true;
 
    //     PlayerController.GetInstance().RegisterClickPressed();    


    // }
    // public void showPauseButton(){
    //     pauseButton.SetActive(true);
    //     Debug.Log("Enabled pause button(?)");
    //     Debug.Log(pauseButton);
    // }
    // public void resumeGame(){
    //     PauseMenuCanvas.SetActive(false);
    //     showPauseButton();

    //     isPaused = false;

    //     PlayerController.GetInstance().RegisterClickPressed();  


    // }
    // public void quitGame(){
    //     PlayerController.GetInstance().RegisterClickPressed();   
    //     SceneManager.LoadScene(0);
    // }
}
