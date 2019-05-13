using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public float rotateSpeed;

    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, 40 * Time.deltaTime); 
        }

        if(Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(Vector3.zero, -Vector3.up, 40 * Time.deltaTime); 
        }
}
}
