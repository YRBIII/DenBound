using System.Collections;
using UnityEngine;

// Controls spawning and respawning of fish using multiple spawn points
public class FishSpawnerManager : MonoBehaviour
{
    public static FishSpawnerManager instance;

    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject fishPrefab;
    [SerializeField] private float respawnDelay = 3f;

    private GameObject currentFish;
    private bool isRespawning;

    // Ensures only one FishSpawnerManager exists in the scene
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    // Spawns the first fish when the scene starts
    private void Start()
    {
        SpawnFish();
    }

    // Spawns a single fish at a random spawn point
    private void SpawnFish()
    {
        if (currentFish != null) return;

        int index = Random.Range(0, spawners.Length);
        Transform spawnPoint = spawners[index];

        currentFish = Instantiate(fishPrefab, spawnPoint.position, spawnPoint.rotation);
        isRespawning = false;
    }

    // Called when the current fish is collected or falls back into the water
    public void FishReturnedToWater()
    {
        if (isRespawning) return;

        isRespawning = true;

        if (currentFish != null)
        {
            Destroy(currentFish);
            currentFish = null;
        }

        StartCoroutine(RespawnAfterDelay());
    }

    // Waits for a short delay before spawning the next fish
    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnFish();
    }
}
