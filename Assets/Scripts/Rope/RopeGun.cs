using UnityEngine;

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _spring = 100f;
    [SerializeField] private float _damper = 5f;
    private SpringJoint _springJoint; 
    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot(); 
        }
    }

    private void Shot()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
        }
        _hook.StopFix();
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.Rigidbody.velocity = _spawn.forward * _speed; 
    }

    public void CreateSpring()
    {
        if (_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = _hook.Rigidbody;
            _springJoint.autoConfigureConnectedAnchor = false; 
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = _spring;
            _springJoint.damper = _damper;
            _springJoint.maxDistance = 3f; 
        }
    }
}
