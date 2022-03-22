using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class TakeDamageOncollision : MonoBehaviour
{
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullet _bullet = collision.gameObject.GetComponent<Bullet>();
        if(_bullet)
        {
            _enemyHealth.TakeDamage(1); 
        }
    }
}
