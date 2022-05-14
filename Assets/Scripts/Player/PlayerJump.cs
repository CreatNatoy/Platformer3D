using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpedForce;
    [SerializeField] private float _angleGroundJump = 45f;
    [SerializeField] private float _speedRotation = 20f;  
    
    private Rigidbody _rigidbody;
    private bool _isGround;
    private int _jumpFrameCounter;

    public bool IsGround => _isGround;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        _jumpFrameCounter += 1; 
        if (_jumpFrameCounter == 2)
        {
            RotationJump(); 
        }
    }

    public void Jump()
    {
        _rigidbody.AddForce(0, _jumpedForce, 0, ForceMode.VelocityChange);

        _jumpFrameCounter = 0;
    }

    private void RotationJump()
    {
        _rigidbody.freezeRotation = false;
        _rigidbody.AddRelativeTorque(0f,0f,_speedRotation, ForceMode.VelocityChange);
    }

    private bool CheckDownGround(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < _angleGroundJump)
            {
                _rigidbody.freezeRotation = true;
                return true;
            }
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