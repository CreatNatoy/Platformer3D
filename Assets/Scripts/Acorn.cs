using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotationSpeed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.AddRelativeForce(_velocity, ForceMode.VelocityChange);
        _rigidbody.AddTorque(RandomRotationSpeed(), RandomRotationSpeed(), RandomRotationSpeed()); 
    }

    private float RandomRotationSpeed()
    {
        return Random.Range(_maxRotationSpeed, _maxRotationSpeed);
    }
}
