using UnityEngine;

public class TakeDamageOnTrigger : TakeDamage
{
    private void OnTriggerEnter(Collider other)
    {
            Bullet _bullet = other.gameObject.GetComponent<Bullet>();
            if (_bullet)
            {
                _enemyHealth.TakeDamage(1);
            }

            if (_dieOnAnyCollision)
            {
                _enemyHealth.TakeDamage(100);
            }
    }
}
