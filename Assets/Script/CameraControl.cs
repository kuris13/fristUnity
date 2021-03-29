using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;

    Vector3 offset;

    //public float dist = 5f;

    public float xSpeed = 220f;
    public float ySpeed = 100f;

    private float x = 0f;
    private float y = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        offset = player.position - transform.position;
        x = offset.y;
        y = offset.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
        y += Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

        Quaternion rotation = Quaternion.Euler(-y, x, 0);

        transform.position = player.position - offset;
        transform.rotation = rotation;
    }
}
