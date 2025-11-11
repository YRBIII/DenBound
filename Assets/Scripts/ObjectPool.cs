using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Singleton reference for easy access from other scripts
    public static ObjectPool Instance;

    [Header("Pool Settings")]
    [SerializeField] private GameObject objectToPool; // Prefab to pool
    [SerializeField, Range(1, 50)] private int maxPooledObjects = 10; // Number of objects in pool
    private GameObject[] pooledObjects; // Array to store pooled objects

    [Header("Spawn Settings")]
    [SerializeField] private BoxCollider spawnVolume; // Volume where objects will spawn
    [SerializeField, Range(0.1f, 10f)] private float spawnInterval = 2f; // Time between spawns

    private void Awake()
    {
        // Setup singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate pools
        }
    }

    private void Start()
    {
        // Initialize the pool array
        pooledObjects = new GameObject[maxPooledObjects];

        for (int i = 0; i < maxPooledObjects; i++)
        {
            GameObject tempObj = Instantiate(objectToPool); // Create clone of prefab
            tempObj.SetActive(false); // Keep inactive until needed
            pooledObjects[i] = tempObj;
        }

        // Start the coroutine to spawn objects over time
        StartCoroutine(SpawnRoutine());
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Length; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        // No available objects; log warning
        Debug.LogWarning("No inactive pooled objects available!");
        return null;
    }

    public void SpawnPooledObject()
    {
        GameObject obj = GetPooledObject();

        if (obj != null && spawnVolume != null)
        {
            // Get world position and size of spawn volume
            Vector3 center = spawnVolume.center + spawnVolume.transform.position;
            Vector3 size = spawnVolume.size;

            // Pick random position inside the box
            float x = Random.Range(center.x - size.x / 2f, center.x + size.x / 2f);
            float y = Random.Range(center.y - size.y / 2f, center.y + size.y / 2f);
            float z = Random.Range(center.z - size.z / 2f, center.z + size.z / 2f);

            obj.transform.position = new Vector3(x, y, z);
            obj.SetActive(true);
        }
    }
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnPooledObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}