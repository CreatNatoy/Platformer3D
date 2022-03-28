using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler; 
    [SerializeField] private Vector3 _rightEuler;
    [SerializeField] private float _speed;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = PlayerSingleton.Instance.transform; 
    }

    private void Update()
    {
        if (transform.position.x < _playerTransform.position.x)
            Rotate(_rightEuler);
        else
            Rotate(_leftEuler);
    }

    private void Rotate(Vector3 toRotate)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(toRotate), Time.deltaTime * _speed);
    }
}
