using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraCenter;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward*100f, Color.red);
    }
}
