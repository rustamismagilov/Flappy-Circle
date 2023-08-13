using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab; // Reference to the coin prefab
    public GameObject obstaclePrefab; // Reference to the obstacle prefab
    public Transform spawnPoint; // Reference to the spawn point empty GameObject

    public float minCoinSpawnInterval = 2.0f; // Minimum time interval between coin spawns
    public float maxCoinSpawnInterval = 4.0f; // Maximum time interval between coin spawns
    public float minObstacleSpawnInterval = 3.0f; // Minimum time interval between obstacle spawns
    public float maxObstacleSpawnInterval = 6.0f; // Maximum time interval between obstacle spawns

    private float nextCoinSpawnTime = 0.0f; // Time to perform the next coin spawn
    private float nextObstacleSpawnTime = 0.0f; // Time to perform the next obstacle spawn

    private void Start()
    {
        // Initialize the initial spawn times for coins and obstacles
        nextCoinSpawnTime = Time.time + GetRandomSpawnInterval(minCoinSpawnInterval, maxCoinSpawnInterval);
        nextObstacleSpawnTime = Time.time + GetRandomSpawnInterval(minObstacleSpawnInterval, maxObstacleSpawnInterval);
    }

    private void Update()
    {
        // Check if it's time to spawn a new coin
         
        if (Time.time >= nextCoinSpawnTime)
        {
            SpawnCoin();
            // Update the next coin spawn time
            nextCoinSpawnTime = Time.time + GetRandomSpawnInterval(minCoinSpawnInterval, maxCoinSpawnInterval);
        }
        

        // Check if it's time to spawn a new obstacle
        if (Time.time >= nextObstacleSpawnTime)
        {
            SpawnObstacle();
            // Update the next obstacle spawn time
            nextObstacleSpawnTime = Time.time + GetRandomSpawnInterval(minObstacleSpawnInterval, maxObstacleSpawnInterval);
        }
    }

    private void SpawnCoin()
    {
        // Instantiate the coin prefab at the spawn point's position
        Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void SpawnObstacle()
    {
        // Instantiate the obstacle prefab at the spawn point's position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
    }

    private float GetRandomSpawnInterval(float minInterval, float maxInterval)
    {
        // Generate a random spawn interval within the specified range
        return Random.Range(minInterval, maxInterval);
    }
}
