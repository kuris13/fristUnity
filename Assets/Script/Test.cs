using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Transform thirdCamPos;
    public Transform firePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(thirdCamPos.position, thirdCamPos.forward * 200.0f, Color.green);

        RaycastHit temp;

        if (Physics.Raycast(thirdCamPos.position, thirdCamPos.forward, out temp, 200.0f)) // 카메라의 위치에서 카메라가 바라보는 정면으로 레이를 쏴서 충돌확인
        {
            // 충돌이 검출되면 총알의 리스폰포인트(firePos)가 충돌이 발생한위치를 바라보게 만든다. 
            // 이 상태에서 발사입력이 들어오면 총알은 충돌점으로 날아가게 된다.
            firePos.LookAt(temp.point);
            Debug.DrawRay(firePos.position, firePos.forward * 200.0f, Color.cyan); // 이 레이는 앞서 선언한 디버그용 레이와 충돌점에서 교차한다
        }
    }
}
