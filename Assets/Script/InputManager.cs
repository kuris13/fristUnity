using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float fHor;

    public float Speed;

    public Transform cameraCenter;
    public Transform temp;

    public float xSpeed = 220f;
    public float ySpeed = 100f;

    Vector3 moveDir;


    private void Start()
    {
        Speed = 2f;
        moveDir = new Vector3(
                cameraCenter.forward.x,
                0f,
                cameraCenter.forward.z).normalized;
    }

    private void Update()
    {
        if (GameManager.GetInstance.MouseMode)
        {
            
            
            
        }
        LookAround();
        
        KeyboardInput();
        MouseInput();


    }

    void LookAround()
    {
        if (GameManager.GetInstance.MouseMode)
        {
            Vector2 mouseDleta = new Vector2(Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y"));
            Vector3 camAngle = cameraCenter.rotation.eulerAngles;

            float x = camAngle.x - mouseDleta.y;

            if (x < 180f)
                x = Mathf.Clamp(x, -25f, 40f);
            else
                x = Mathf.Clamp(x, 335f, 415f);


            cameraCenter.rotation = Quaternion.Euler(x,
                camAngle.y + mouseDleta.x, camAngle.z);
        }
    }

    void EnterMouseMode()
    {
        //마우스 모드 == 커서 보임 
        //마우스를 감춰서 전투에 집중 / 시야 조정
        if(Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GameManager.GetInstance.MouseMode = true;
        }
        //마우스 커서를 꺼내서 ui작업
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<PlayerFSM>().Attack(0);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            GetComponent<PlayerFSM>().Attack(1);
        }




    }

    void KeyboardInput()
    {

        fHor = Input.GetAxis("Horizontal");
        float fVer = Input.GetAxis("Vertical");

        Vector3 lookForward = new Vector3(
                cameraCenter.forward.x,
                0f,
                cameraCenter.forward.z).normalized;

        Vector3 lookRight = new Vector3(
            cameraCenter.right.x,
            0f,
            cameraCenter.right.z).normalized;

        
        

        if (fHor != 0 || fVer != 0)
            moveDir = lookForward * fVer + lookRight * fHor;

            // runMode
            // 달릴 때는 앞뒤좌우로 다 이동 가능함!!

            Vector3 runMode = moveDir.normalized;


        //walkMode
        //걸을 때는 앞으로만 걸을 수 있음
        // 옆, 뒤는 다른 모션으로 모션을 다르게할 거임
        //temp.forward = lookForward;

        temp.forward = runMode;

        if (fHor != 0 || fVer != 0)
        {
            GetComponent<PlayerFSM>().MoveTo(fVer,fHor);



            

            transform.position += moveDir * Time.deltaTime * 5f;
        }
            

            
        
        
            //GetComponent<PlayerFSM>().TurnTo(fHor);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<PlayerFSM>().Jump();
        }

        if(Input.GetKeyDown(KeyCode.LeftCommand))
        {
            
            EnterMouseMode();
        }
        /*
        //손을 누르거나 땟을 때
        if (fVer < 1f && fVer > -1f && fVer != 0f)
        {
            //내가 이미 움직이는 중이 아니라면 -> 바로 무브시켜야함
            if(!GetComponent<PlayerFSM>().IsMove())
                GetComponent<PlayerFSM>().MoveTo(fVer);
            //움직이는 중이라면 -> 무브 시키지 말아야함 
            else if(GetComponent<PlayerFSM>().IsMove())
            {
                GetComponent<PlayerFSM>().MoveStop();
            }
        }

       if(fVer == 1f || fVer == -1f)
        {
            GetComponent<PlayerFSM>().MoveTo(fVer);
        }
        */
    }



}
