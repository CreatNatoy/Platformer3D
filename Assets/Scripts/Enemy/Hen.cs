using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hen : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToReachSpeed = 1f; 

    private Rigidbody _rigidbody;
    private Transform _playerTransform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
        _playerTransform = PlayerSingleton.Instance.transform; 
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toPlayer * _speed - _rigidbody.velocity) / _timeToReachSpeed;

        _rigidbody.AddForce(force); 
    }
}
