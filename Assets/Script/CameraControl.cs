using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //public Transform cameraCenter;
    /*
    int EnemyLayerMask;

    private float zoomDistance;

    private void Start()
    {
        EnemyLayerMask = (-1) -(1 << LayerMask.NameToLayer("Player"));
        zoomDistance = 0.0f;
    }
    private void Update()
    {

        if(Physics.Raycast(transform.position, transform.forward *100f,  out RaycastHit hit,15f, EnemyLayerMask))
        {
            GameManager.GetInstance.curTarget = hit.transform.gameObject;
        }

        Debug.DrawRay(transform.position, transform.forward*100f, Color.red);

    }
    void MouseWheel()
    {
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel") * -1;

        zoomDistance += ScrollWheel * 10;

        if (zoomDistance < 20f)
            zoomDistance = 20f;
        if (zoomDistance > 60f)
            zoomDistance = 60f;
    }
     */

    void StartShake()
    {
        
    }

    private void Update()
    {
        //LookAround();
    }

    

}
