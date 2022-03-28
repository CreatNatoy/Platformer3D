using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class TakeDamage : MonoBehaviour
{
    [SerializeField] protected bool _dieOnAnyCollision;

    protected EnemyHealth _enemyHealth;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }
}
