using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
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
        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed, 0, 0, ForceMode.VelocityChange);
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
