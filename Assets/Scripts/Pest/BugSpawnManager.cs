using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawnManager : MonoBehaviour
{
    //[SerializeField] private GameObject bugPrefab;

    private AudioSource source;

    private float spawnTimer;
    private float minTimer = 20f;
    private float maxTimer = 25f;

    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTimer(minTimer, maxTimer);
        source = GetComponent<AudioSource>();
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
        GameObject bug = ObjectPool.SharedInstance.GetObject("Pest");
        if (bug != null)
        {
            bug.transform.position = new RandomMovePosition().position;
            bug.SetActive(true);
        }
        //Instantiate(bugPrefab, new RandomMovePosition().position, bugPrefab.transform.rotation);
    }

    private void ResetSpawnTimer(float min, float max)
    {
        minTimer *= 0.95f;
        maxTimer *= 0.95f;
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
            ResetSpawnTimer(minTimer, maxTimer);
        }
        return spawnTimer;
    }

    private void PlaySquishSound()
    {
        source.Play();
    }

    private void OnEnable()
    {
        ActionList.OnBugKilled += PlaySquishSound;
    }

    private void OnDisable()
    {
        ActionList.OnBugKilled -= PlaySquishSound;
    }
}
