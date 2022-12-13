using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameStartScene;
    public void StartGame(){
        SceneManager.LoadScene(gameStartScene);
    }
}
