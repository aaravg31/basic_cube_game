using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Reference back to the spawner that created this coin
    // Hidden in the Inspector so it won’t clutter the UI, but can be set in code
    [HideInInspector] public CoinSpawner spawner;
    
    // Sound to play when the coin is collected
    [SerializeField] private AudioClip collectSound;
    
    // Called when another collider enters this coin’s trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player (has a playerHandler script)
        playerHandler ph = other.GetComponent<playerHandler>();
        if (ph != null)
        {
            // Increase player’s score
            ph.IncreasePoints();
            
            // Play collection sound effect at coin’s position
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            
            // Ask the spawner to generate a new coin elsewhere
            spawner.SpawnCoin();
            
            // Destroy this coin object since it’s been collected
            Destroy(this.gameObject);
        }
    }
}
