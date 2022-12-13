//using System.Threading.Tasks.Dataflow;
using System;
using System.Numerics;
using System.Transactions;
//using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    [SerializeField]
    float timeOffset;

    [SerializeField]
    Vector2 posOffset;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;
    private Vector3 velocity;


    //public float speed;
    // private float currentPosX;
    // private Vector3 velocity = Vector3.zero;
    public float yOffset;
    public Transform playerTransform;

    private GameObject _player;

    // Start is called before the first frame update

    void Start()
    {

    }

    void initializationWait(){
        _player = GameObject.Find("player(Clone)");
    }
    private void Update() {
       // transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
       //

        Vector3 startPos = transform.position;

        Vector3 endPos = playerTransform.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        //transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
       // transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset, 15f);
        transform.position = new UnityEngine.Vector3(playerTransform.position.x, playerTransform.position.y + yOffset, transform.position.z);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );

    } //establishing code
    
    private void OnDrawGizmos(){//draw a dev reference for the camera boundary
        //draw a box around the camera boundary
        Gizmos.color = Color.red;
        //draw using limits we set in editor
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));

    }    //12:27
    

    // Update is called once per frame
    // void Update() //re-rendering every frame
    // {

    // }
}
