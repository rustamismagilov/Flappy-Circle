using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab; // Reference to the coin prefab
    public GameObject obstaclePrefab; // Reference to the obstacle prefab
    public Transform spawnPoint; // Reference to the spawn point empty GameObject

    public float spawnInterval = 2.0f; // Time interval between spawns
    private float nextSpawnTime = 0.0f; // Time to perform the next spawn

    private void Update()
    {
        // Check if it's time to spawn a new object
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            // Update the next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnObject()
    {
        // Randomly determine whether to spawn a coin or an obstacle
        bool spawnCoin = Random.Range(0, 2) == 0;

        // Determine the prefab to spawn based on the random choice
        GameObject prefabToSpawn = spawnCoin ? coinPrefab : obstaclePrefab;

        // Instantiate the chosen prefab at the spawn point's position
        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
