using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpedForce;
    [SerializeField] private float _angleGroundJump = 45f; 
    [SerializeField] private float _friction;

    private Rigidbody _rigidbody;
    private bool _isGround;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float speedMultuplier = 1f;

        if (!_isGround)
            speedMultuplier = 0.2f;
        
        if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            speedMultuplier = 0f;
        if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            speedMultuplier = 0f;

        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultuplier, 0, 0, ForceMode.VelocityChange);

        if(_isGround)
        ResistanceVelocity();
    }

    private void ResistanceVelocity()
    {
        _rigidbody.AddForce(- _rigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
    }

    private void Jump()
    {
        _rigidbody.AddForce(0, _jumpedForce, 0, ForceMode.VelocityChange);
    }

    private bool CheckDownGround(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < _angleGroundJump)
                return true; 
        }
        return false; 
    }

    private void OnCollisionStay(Collision collision)
    {
        _isGround = CheckDownGround(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGround = false; 
    }
}
