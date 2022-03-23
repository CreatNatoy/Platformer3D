using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private SoundEffects _soundEffects;
    [SerializeField] private HealthUI _healthUI;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }

    private bool _invulnerable = false; 

    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            _health = Mathf.Max(_health - damageValue, 0);
            if (_health <= 0)
                Die();
        }
        _invulnerable = true;
        Invoke("StopInvulnerable", 1f);
        _soundEffects.MeHitSound();
        _healthUI.DisplayHealth(_health);
    }

    private void StopInvulnerable()
    {
        _invulnerable = false; 
    }

    private void Die()
    {
        Debug.Log("You Lose");
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if (_health > _maxHealth)
            _health = _maxHealth;
        _soundEffects.PickUpHealthSound();
        _healthUI.DisplayHealth(_health);
    }

}
