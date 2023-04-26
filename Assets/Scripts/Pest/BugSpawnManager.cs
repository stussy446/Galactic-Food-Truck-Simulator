using UnityEngine;

public class BugSpawnManager : MonoBehaviour
{
    private AudioSource source;

    private float spawnTimer;
    private float minTimer = 20f;
    private float maxTimer = 25f;
    private int activeBugs = 0;

    private void Start()
    {
        ResetSpawnTimer(minTimer, maxTimer);
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
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
            activeBugs++;
            bug.transform.position = new RandomMovePosition().position;
            bug.SetActive(true);
        }
        if(activeBugs >= 3)
        {
            ActionList.OnTooManyBugs(ActionType.TooManyBugs);
        }
    }
    
    /// <summary>
    /// Resets the bug spawn timer based on a randomly generated time
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
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
        activeBugs--;
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
