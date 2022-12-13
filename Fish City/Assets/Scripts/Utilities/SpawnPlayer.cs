using System.Transactions;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    void Start(){
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
