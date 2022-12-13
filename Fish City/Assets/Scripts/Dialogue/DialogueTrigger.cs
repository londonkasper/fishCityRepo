using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//public myInstance;
public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    // bool isPlaying = false;


    private bool playerInRange;
    // void Start(){
    //     isPlaying  = DialogueManager.GetInstance().dialogueIsPlaying;
    // }

    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() 
    {
        //Debug.Log("Dialogue is playing: " + DialogueManager.GetInstance().dialogueIsPlaying);
        //if (playerInRange && !isPlaying) 
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) 
        {
            visualCue.SetActive(true);
            if (PlayerController.GetInstance().GetInteractPressed()) 
            {
               DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
               //Debug.Log(inkJSON.text);
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }



    private void OnTriggerEnter2D(Collider2D collider) 
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
