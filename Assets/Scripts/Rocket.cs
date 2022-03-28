using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rotationSpeed = 2f;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = PlayerSingleton.Instance.transform;
    }

    private void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
