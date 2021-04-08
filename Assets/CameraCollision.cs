using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform Player;
    public RaycastHit raycastHit;
    int layerMask;
    public Camera CameraM;
    public GameObject oldObject;
    public GameObject curObject;
    Ray ray;
    public float Distance;
    // Start is called before the first frame update
    /*
    void Start()
    {
        //layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));
    }
     */

    // Update is called once per frame
    /*
void Update()
{
    //Debug.DrawRay(transform.position, Player.position, Color.blue);
    ray = CameraM.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
    Debug.DrawRay(new Vector3(ray.origin.x+0.8f, ray.origin.y-0.8f, ray.origin.z),this.transform.forward.normalized *Distance *0.7f, Color.blue);

    ray.origin = new Vector3(ray.origin.x + 0.8f, ray.origin.y - 0.8f, ray.origin.z);
    Distance = Vector3.Distance(transform.position, Player.position);

    if (Physics.Raycast(ray, out raycastHit,Distance- 0.1f,layerMask))
    {
        curObject = raycastHit.transform.gameObject;

        // 카메라와 케릭터 사이에 새로운 물체가 끼어듬
        if (curObject != null)
        {
            curObject.GetComponent<MeshRenderer>().enabled = false;
        }


        //여기까지함 0407
        //어차피 들어오는 오브젝트는 하나
        // 즉 뉴 올드 비교 x -> 충돌한다면 끄고 충돌하지 않는다면 킨다

        Debug.Log("aaa");
    }


    if(curObject != null)
        oldObject = curObject;
    else if (oldObject != null)
    {
        oldObject.GetComponent<MeshRenderer>().enabled = true;
        oldObject = null;
    }
    curObject = null;
}
}
     */

}