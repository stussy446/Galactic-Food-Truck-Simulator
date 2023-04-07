using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject bugPrefab;

    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTimer();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBug();
    }

    private void SpawnBug()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Instantiate(bugPrefab, new RandomMovePosition().position, Quaternion.identity);
            ResetSpawnTimer();
        }
    }

    private void ResetSpawnTimer()
    {
        spawnTimer = Random.Range(15f, 24f);
    }
}
