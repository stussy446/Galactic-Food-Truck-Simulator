using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject bugPrefab;

    private float spawnTimer;
    private float minTimer = 17f;
    private float maxTimer = 19f;

    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTimer(minTimer, maxTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gamePaused == true)
            return;

        GetSpawnTimer();
    }

    private void SpawnBug()
    {
        Instantiate(bugPrefab, new RandomMovePosition().position, bugPrefab.transform.rotation);
    }

    private void ResetSpawnTimer(float min, float max)
    {
        spawnTimer = Random.Range(min, max);
    }

    /// <summary>
    /// Decreases the time a bug will spawn by 5%
    /// </summary>
    /// <returns></returns>
    private float GetSpawnTimer()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnBug();
            minTimer *= 0.95f;
            maxTimer *= 0.95f;
            ResetSpawnTimer(minTimer, maxTimer);
        }
        return spawnTimer;
    }
}
