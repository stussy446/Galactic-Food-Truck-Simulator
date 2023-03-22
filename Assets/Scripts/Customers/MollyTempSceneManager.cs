using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollyTempSceneManager : MonoBehaviour
{

    //temporarily acting as other elements of game structure.
    [SerializeField]
    private Transform customerSpawnLocation;
    [SerializeField]
    private GameObject alienCustomer;

    [SerializeField]
    public bool correctOrderFufilled;

    void Start()
    {
        //instantiates customer prefab that has customer state machine attached
        Instantiate(alienCustomer, customerSpawnLocation);
    }
   
}
