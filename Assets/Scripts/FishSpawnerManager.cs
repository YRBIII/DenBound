using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnerManager : MonoBehaviour
{
    public static FishSpawnerManager instance;

    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject fishPrefab;
    [SerializeField] private float respawnDelay = 3f;

    private GameObject currentFish;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnFish();
    }

    public void SpawnFish()
    {
        int index = Random.Range(0, spawners.Length);
        Transform spawnPoint = spawners[index];

        currentFish = Instantiate(fishPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void FishReturnedToWater()
    {
        if (currentFish != null)
            Destroy(currentFish);

        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnFish();
    }
}