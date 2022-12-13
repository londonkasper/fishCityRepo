using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class foundDocOc : MonoBehaviour
{
    public string levelName;
    void Update()
    {
        if(staticVars.hasFoundOc){
            SceneManager.LoadScene("MainMenu");
            staticVars.hasFoundOc = false;
        }
    }
}
