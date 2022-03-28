using UnityEngine;

public class MakeDamageOnCollision : MakeDamage
{
    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponentInParent<PlayerHealth>();
        if (playerHealth)
            playerHealth.TakeDamage(_damageValue); 
    }
}
