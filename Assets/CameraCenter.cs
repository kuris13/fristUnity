using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    public Transform Player;
    public Camera MainCamera;
    public Camera SubCamera;

    public float camera_distance = 0f;  //리그로부터 카메라까지의 거리
    public float camera_width = -2.5f; // 가로 거리 z값 
    public float camera_height = 0f;    // 세로 거리 y값 
    public float camera_x = 0.7f;
    Vector3 dir;

    private void Start()
    {
        // 카메라까지의 거리
        camera_distance = Vector3.Distance(transform.position, MainCamera.transform.position);
        
        // 카메라까지의 방향벡터
        dir = new Vector3(camera_x, camera_height, camera_width);

        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        //Debug.DrawLine(transform.position, dir, Color.black);

        transform.position = new Vector3(
            Player.position.x,
            Player.position.y + 1.5f,
            Player.position.z);
        

        Vector3 ray_target = transform.up * camera_height
            + transform.forward * camera_width
            + transform.right * camera_x;

        RaycastHit hitinfo;

        if (Physics.Raycast(transform.position, ray_target, out hitinfo, camera_distance))
        {
            MainCamera.transform.position = new Vector3(hitinfo.point.x , hitinfo.point.y, hitinfo.point.z) ;
            MainCamera.transform.Translate(dir * -1 * 0.5f);

            MainCamera.enabled = false;
            SubCamera.enabled = true;

        }
        else
        {
            MainCamera.transform.localPosition = new Vector3(camera_x, camera_height, camera_width);

            MainCamera.enabled = true;
            SubCamera.enabled = false;

            // 작동하지말것!
            /*
            MainCamera.transform.position = new Vector3(
                transform.position.x + camera_x,
                transform.position.y + camera_height,
                transform.position.z + camera_width);
             */

        }
         
    }

}
