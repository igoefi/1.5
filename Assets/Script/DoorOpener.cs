using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Rigidbody _body;

    private int moveCoef;
    [SerializeField] int TimeToRotation;
    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveCoef = 1;
        if (Time.time >= TimeToRotation * 2)
        {
            moveCoef = 0;
        }
        else if (Time.time >= TimeToRotation)
        {
            moveCoef = -1;
        }
    }

    private void FixedUpdate()
    {
        _body.velocity = new Vector3(0, 0, 1 * moveCoef);
    }
}
