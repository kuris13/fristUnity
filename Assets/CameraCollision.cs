using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform Player;
    public RaycastHit raycastHit;
    int layerMask;

    GameObject oldObject =null;
    GameObject curObject = null;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, Player.position, Color.blue);

        if (Physics.Raycast(transform.position,Player.position, out raycastHit,layerMask))
        {
            curObject = raycastHit.transform.gameObject;

            // 카메라와 케릭터 사이에 새로운 물체가 끼어듬
            if (curObject != oldObject)
            {

            }

            //여기까지함 0407
            //어차피 들어오는 오브젝트는 하나
            // 즉 뉴 올드 비교 x -> 충돌한다면 끄고 충돌하지 않는다면 킨다

            Debug.Log("aaa");
        }



        oldObject = curObject;

    }
}
