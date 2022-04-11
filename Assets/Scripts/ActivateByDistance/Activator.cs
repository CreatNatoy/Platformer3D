using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private List<ActivateByDistance> _objectsToActivate = new List<ActivateByDistance>();
    [SerializeField] private Transform _playerTransform;

    private void Awake()
    {
        GetComponentsInChildren(_objectsToActivate);
    }

    private void Update()
    {
        for (int i = 0; i < _objectsToActivate.Count; i++)
        {
            if (_objectsToActivate[i] != null)
                _objectsToActivate[i].CheckDistance(_playerTransform.position);
            else
                _objectsToActivate.RemoveAt(i);
        }
    }
}
