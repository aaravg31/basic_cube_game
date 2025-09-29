using UnityEngine;

public class OrbColourCycle : MonoBehaviour
{
    // The Renderer that displays the orb (drag in via Inspector)
    [SerializeField] private Renderer orbRenderer; 
    
    // How long the orb exists before disappearing (should match TrailScript orbLifetime)
    [SerializeField] private float lifetime = 5f; 

    // Internal reference to the orb's material (so each orb has its own unique instance)
    private Material orbMaterial;
    
    // When this orb was spawned
    private float spawnTime;

    void Start()
    {
        // Get a unique material instance so we don't affect all orbs at once
        orbMaterial = orbRenderer.material;
        
        // Record the spawn time so we can track lifetime progress
        spawnTime = Time.time;
    }

    void Update()
    {
        // How far along its lifetime the orb is (0 → 1)
        float age = (Time.time - spawnTime) / lifetime;
        age = Mathf.Clamp01(age); // ensure stays in [0, 1]

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

        // Apply color to orb material and make it glow by setting Emission
        orbMaterial.color = finalColor;
        orbMaterial.SetColor("_EmissionColor", finalColor * 2f);
    }
}
