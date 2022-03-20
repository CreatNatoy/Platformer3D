using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpedForce;
    [SerializeField] private float _angleGroundJump = 45f;

    private bool _isGround;
    private Rigidbody _rigidbody;

    public bool IsGround => _isGround; 

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            Jump();
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
