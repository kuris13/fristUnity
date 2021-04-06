using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    Ray ray;
    public RaycastHit rayHit;
    public Camera camera;

    public float MAX_RAY_DISTANCE = 500.0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out rayHit, MAX_RAY_DISTANCE))
        {
            Debug.DrawLine(ray.origin, rayHit.point, Color.green);
            GameManager.GetInstance.AimTarget.position = rayHit.point;
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }

    

}
