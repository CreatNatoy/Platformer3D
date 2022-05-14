using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("JumP");
            _rigidbody.AddForce(Vector3.up * 10f, ForceMode.VelocityChange);
            _rigidbody.AddRelativeTorque(0,0, 10f, ForceMode.VelocityChange);
        }
    }
}
