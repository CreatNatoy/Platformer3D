using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private Camera _playerCamera;

    private Vector3 _toAim;

    public Vector3 ToAim => _toAim; 

    private void LateUpdate()
    {
        AimToMousePosition();
        GunLookAim();
    }

    private void AimToMousePosition()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        _aim.position = point;
    }

    private void GunLookAim()
    {
        _toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(_toAim); 
    }
}
