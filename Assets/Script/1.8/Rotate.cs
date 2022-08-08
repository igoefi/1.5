using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationVelocity;

    void Update()
    {
        Quaternion deltaRotation = Quaternion.Euler(rotationVelocity * Time.deltaTime);
        transform.rotation = deltaRotation * transform.rotation;
    }
}
