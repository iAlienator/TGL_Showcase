using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera;

    private void LateUpdate()
    {
        Camera.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.transform.position.z);
    }
}
