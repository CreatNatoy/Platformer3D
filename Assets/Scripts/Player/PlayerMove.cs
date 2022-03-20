using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerJump))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _friction;

    private Rigidbody _rigidbody;
    private PlayerJump _playerJump; 

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerJump = GetComponent<PlayerJump>(); 
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float speedMultuplier = 1f;

        if (!_playerJump.IsGround)
            speedMultuplier = 0.2f;
        
        if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            speedMultuplier = 0f;
        if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            speedMultuplier = 0f;

        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultuplier, 0, 0, ForceMode.VelocityChange);

        if(_playerJump.IsGround)
        ResistanceVelocity();
    }

    private void ResistanceVelocity()
    {
        _rigidbody.AddForce(- _rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
    }
}
