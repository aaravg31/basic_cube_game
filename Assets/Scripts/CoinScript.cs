using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [HideInInspector] public CoinSpawner spawner;
    
    [SerializeField] private AudioClip collectSound;
    private void OnTriggerEnter(Collider other)
    {
        playerHandler ph = other.GetComponent<playerHandler>();
        if (ph != null)
        {
            ph.IncreasePoints();
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            spawner.SpawnCoin();
            Destroy(this.gameObject);
        }
    }
}
