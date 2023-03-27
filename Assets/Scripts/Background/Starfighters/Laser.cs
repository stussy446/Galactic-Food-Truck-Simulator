using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject explodey;
    private float boomTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Boomboom", boomTimer);
    }

    void Boomboom()
    {
        Instantiate(explodey, spawnPoint);
    }


}
