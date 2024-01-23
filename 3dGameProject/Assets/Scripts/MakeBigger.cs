using UnityEngine;

public class SphereGrowth : MonoBehaviour
{
    public float growthRate = 1.0f; // Snelheid waarmee de bol per seconde groeit

    private void Update()
    {
        // maakt de bol groter
        transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;
    }
}
