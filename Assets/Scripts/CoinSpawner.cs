using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private BoxCollider groundCollider;
    [SerializeField] private int coinAmount;
    void Start()
    {

        for (int i = 0; i < coinAmount; i++)
        {
            SpawnCoin();
        }
        
    }
    public void SpawnCoin()
    {
        Vector3 startPos = RandomPointInBounds(groundCollider.bounds);
        GameObject coin = Instantiate(coinPrefab, startPos, Quaternion.identity);

        // Tell the coin who spawned it
        coin.GetComponent<CoinScript>().spawner = this;
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x), 
            1f, 
            Random.Range(bounds.min.z, bounds.max.z));
    }

    void Update()
    {
        
    }
}
