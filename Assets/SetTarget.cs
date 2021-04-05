using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    public Vector3 ScreenCenter;
    Ray ray;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
       ray = camera.ScreenPointToRay(ScreenCenter);

       
    }

    // Update is called once per frame
    void Update()
    {
        
        //화면 중앙
        ScreenCenter = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2);
        


        ray.origin = transform.position;

        if (Physics.Raycast(ray.origin, ScreenCenter , out RaycastHit hit, 15f))
        {
            Debug.DrawRay(ray.origin, ScreenCenter, Color.green, 15f);
        }

    }
}
