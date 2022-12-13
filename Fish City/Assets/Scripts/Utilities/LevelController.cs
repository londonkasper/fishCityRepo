using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour{

    public int index;
    public string levelName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            //SceneManager.LoadScene(index);

            
            SceneManager.LoadScene(levelName);

            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
