using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // Prefab of the coin to spawn
    [SerializeField] private GameObject coinPrefab;
    
    // Collider that defines the ground area where coins can spawn
    [SerializeField] private BoxCollider groundCollider;
    
    // Number of coins to spawn at the start
    [SerializeField] private int coinAmount;
    void Start()
    {

        for (int i = 0; i < coinAmount; i++)
        {
            // Spawn the initial batch of coins when the game begins
            SpawnCoin();
        }
        
    }
    
    // Spawns a single coin at a random location within the ground area
    public void SpawnCoin()
    {
        // Pick a random point within the BoxCollider’s bounds
        Vector3 startPos = RandomPointInBounds(groundCollider.bounds);
        
        // Instantiate the coin prefab at that position
        GameObject coin = Instantiate(coinPrefab, startPos, Quaternion.identity);

        // Give the coin a reference back to this spawner
        // So it can call SpawnCoin() again when collected
        coin.GetComponent<CoinScript>().spawner = this;
    }

    
    // Helper function: pick a random point inside a Bounds
    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x), 
            1f, 
            Random.Range(bounds.min.z, bounds.max.z));
    }
}
