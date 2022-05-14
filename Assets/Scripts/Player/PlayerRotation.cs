using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Pointer _aimPointer;
    [SerializeField] private float _speedRotation = 8f;
    [SerializeField] private Transform _body; 
    private float _yEuler;

    private void LateUpdate()
    {
        if(_aimPointer.ToAim.x < 0)
        {
            _yEuler = Rotation(45f);
        }
        else
        {
            _yEuler = Rotation(-45f);
        }
        _body.localEulerAngles = new Vector3(0, _yEuler, 0); 
    }

    private float Rotation(float angle)
    {
        return Mathf.Lerp(_yEuler, angle, Time.deltaTime * _speedRotation);
    }
}
