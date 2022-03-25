using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateionSpeed;

    private void Update()
    {
        transform.Rotate(_rotateionSpeed * Time.deltaTime); 
    }
}
