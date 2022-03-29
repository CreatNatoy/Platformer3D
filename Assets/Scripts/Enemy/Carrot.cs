using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Carrot : MonoBehaviour
{
    [SerializeField] private float _force; 

    private Rigidbody _rigidbody;
    private Transform _playerTransform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 

        _playerTransform = PlayerSingleton.Instance.transform;

        CarrotToPlayer();
    }

    private void CarrotToPlayer()
    {
        transform.rotation = Quaternion.identity;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        _rigidbody.AddForce(toPlayer * _force);
    }

}
