using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class enterDoorTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] public string levelName;
    [SerializeField] public int index;
    private bool playerInRange;
    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() 
    {
        //Debug.Log("Dialogue is playing: " + DialogueManager.GetInstance().dialogueIsPlaying);
        //if (playerInRange && !isPlaying) 
        if (playerInRange) //If the player is within the door collider 
        {
            visualCue.SetActive(true); //display the visual cue
            if (PlayerController.GetInstance().GetInteractPressed()) //if they press i
            {
               SceneManager.LoadScene(levelName); //enter the scene specified in the script assignments
               //SceneManager.LoadScene(index);
            }
        }
        else 
        {
            visualCue.SetActive(false); //else they are not in range so don't display the visual cue
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) //This is only referring to the box colliders of the objects
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
