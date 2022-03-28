using UnityEngine;

public class TakeDamageOnCollision : TakeDamage
{
    private void OnCollisionEnter(Collision collision)
    {
        Bullet _bullet = collision.gameObject.GetComponent<Bullet>();
        if(_bullet)
        {
            _enemyHealth.TakeDamage(1); 
        }

        if(_dieOnAnyCollision)
        {
            _enemyHealth.TakeDamage(100);
        }
    }
}
