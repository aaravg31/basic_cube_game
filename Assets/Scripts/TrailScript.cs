using UnityEngine;

public class TrailScript : MonoBehaviour
{
    [SerializeField] private GameObject orbPrefab;
    [SerializeField] private float spawnInterval = 0.3f;  // seconds between orbs
    [SerializeField] private float orbLifetime = 5f;
    
    private float timer;
    
    void Update()
    {
        // Count up the timer
        timer += Time.deltaTime;

        // Drop orb every interval
        if (timer >= spawnInterval)
        {
            SpawnOrb();
            timer = 0f;
        }
    }
    void SpawnOrb()
    {
        // Spawn glowing orb at player's position
        GameObject orb = Instantiate(orbPrefab, transform.position, Quaternion.identity);

        // Destroy orb after X seconds
        Destroy(orb, orbLifetime);
    }
    
}
