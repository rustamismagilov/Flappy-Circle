using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab; // Reference to the coin prefab
    public Transform spawnPoint; // Reference to the spawn point empty GameObject

    private void Start()
    {
        // Instantiate a coin prefab at the spawn point's position
        Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
    }
}
