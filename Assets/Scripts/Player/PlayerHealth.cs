using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private SoundEffects _soundEffects;
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private float _dropDistanceDie = -20f; 
    [SerializeField] private UnityEvent _eventOnTakeDamage; 
    
    private bool _invulnerable;
    
    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }

    private void Update()
    {
        if (transform.position.y < _dropDistanceDie)
        {
            Die();
        }
    }

    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            _health = Mathf.Max(_health - damageValue, 0);
            if (_health <= 0)
                Die();
            _healthUI.DisplayHealth(_health);

            _eventOnTakeDamage?.Invoke();
        }
        _invulnerable = true;
        Invoke("StopInvulnerable", 1f);
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
