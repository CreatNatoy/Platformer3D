using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;

    [SerializeField] private UnityEvent _eventOnTakeDamage; 

    public void TakeDamage(int damageValue)
    {
        _health = Mathf.Max(_health - damageValue, 0);
        if (_health <= 0)
        {
            Die();
        }
        _eventOnTakeDamage?.Invoke(); 
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
