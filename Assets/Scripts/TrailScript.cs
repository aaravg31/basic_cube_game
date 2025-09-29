using UnityEngine;

public class TrailScript : MonoBehaviour
{
    // Prefab of the glowing orb to spawn
    [SerializeField] private GameObject orbPrefab;
    
    // How often to spawn orbs (in seconds)
    [SerializeField] private float spawnInterval = 0.3f;
    
    // How long each orb should exist before being destroyed
    [SerializeField] private float orbLifetime = 5f;
    
    // Internal timer to keep track of spawn intervals
    private float timer;
    
    void Update()
    {
        // Increase timer every frame by the time passed since last frame
        timer += Time.deltaTime;

        // If enough time has passed, spawn an orb
        if (timer >= spawnInterval)
        {
            SpawnOrb();
            // Reset timer back to 0 for the next interval
            timer = 0f;
        }
    }
    void SpawnOrb()
    {
        // Spawn a new orb at the player's current position
        GameObject orb = Instantiate(orbPrefab, transform.position, Quaternion.identity);

        // Destroy orb after orbLifetime seconds
        Destroy(orb, orbLifetime);
    }
    
}
