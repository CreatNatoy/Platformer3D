using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class TakeDamageOncollision : MonoBehaviour
{
    [SerializeField] private bool _dieOnAnyCollision; 

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

        if(_dieOnAnyCollision)
        {
            _enemyHealth.TakeDamage(1);
        }
    }
}
