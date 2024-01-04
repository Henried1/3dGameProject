using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    public float particleDamageAmount = 1.0f;

    void OnParticleCollision(GameObject other)
    {
        // Check if the collided object has a Health script
        Health healthScript = other.GetComponent<Health>();
        if (healthScript != null)
        {
            // Apply damage to the player
            healthScript.ApplyDamage(particleDamageAmount);
        }
    }
}
