using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraCenter;
    int EnemyLayerMask;
    private void Start()
    {
        EnemyLayerMask = (-1) -(1 << LayerMask.NameToLayer("Player"));

    }
    private void Update()
    {

        if(Physics.Raycast(transform.position, transform.forward *100f,  out RaycastHit hit,15f, EnemyLayerMask))
        {
            GameManager.GetInstance.curTarget = hit.transform.gameObject;
        }

        Debug.DrawRay(transform.position, transform.forward*100f, Color.red);

    }
}
