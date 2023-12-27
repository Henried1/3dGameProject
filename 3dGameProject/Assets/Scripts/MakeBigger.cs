using UnityEngine;

public class SphereGrowth : MonoBehaviour
{
    public float growthRate = 1.0f; // Rate at which the sphere grows per second

    private void Update()
    {
        // Increase the scale of the sphere over time
        transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;
    }
}
