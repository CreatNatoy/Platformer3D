using UnityEngine;

public class MakeDamageOnTrigger : MakeDamage
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponentInParent<PlayerHealth>();
        if (playerHealth)
            playerHealth.TakeDamage(_damageValue);
    }
}
