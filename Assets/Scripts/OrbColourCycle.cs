using UnityEngine;

public class OrbColourCycle : MonoBehaviour
{
    [SerializeField] private Renderer orbRenderer;  
    [SerializeField] private float lifetime = 5f; 

    private Material orbMaterial;
    private float spawnTime;

    void Start()
    {
        // Get a unique material instance so we don't affect all orbs at once
        orbMaterial = orbRenderer.material;
        
        spawnTime = Time.time;
    }

    void Update()
    {
        // How far along its lifetime the orb is (0 → 1)
        float age = (Time.time - spawnTime) / lifetime;
        age = Mathf.Clamp01(age);

        // Define key colors
        Color c1 = Color.cyan;              // start
        Color c2 = new Color(0f, 0f, 1f);   // mid (blue)
        Color c3 = new Color(0.5f, 0f, 1f); // final (purple)

        // First half: cyan → blue, second half: blue → purple
        Color finalColor;
        if (age < 0.5f)
            finalColor = Color.Lerp(c1, c2, age * 2f);
        else
            finalColor = Color.Lerp(c2, c3, (age - 0.5f) * 2f);

        // Apply to base + glow
        orbMaterial.color = finalColor;
        orbMaterial.SetColor("_EmissionColor", finalColor * 2f);
    }
}
