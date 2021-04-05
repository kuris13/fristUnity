using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    


    
    public float fHor;
    public float fVer;
    public float Speed;

    public Transform cameraCenter;
    public Transform body;

    public float xSpeed = 220f;
    public float ySpeed = 100f;

    Vector3 moveDir;

    private PlayerFSM playerFSM;

    public Vector3 lookForward;
    public Vector3 lookRight;

    private void Start()
    {
        playerFSM = GetComponent<PlayerFSM>();
        
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
            Vector2 mouseDleta = new Vector2(Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y"));
            
            Vector3 camAngle = cameraCenter.rotation.eulerAngles;

            float x = camAngle.x - mouseDleta.y;

            if (x < 180f)
                x = Mathf.Clamp(x, -25f, 40f);
            else
                x = Mathf.Clamp(x, 335f, 415f);


            cameraCenter.rotation = Quaternion.Euler(
                x,
                camAngle.y + mouseDleta.x,
                camAngle.z);

        lookForward = new Vector3(
                cameraCenter.forward.x,
                0f,
                cameraCenter.forward.z).normalized;

        lookRight = new Vector3(
            cameraCenter.right.x,
            0f,
            cameraCenter.right.z).normalized;
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
            playerFSM.Shot();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            playerFSM.ShotStop();
        }
        if (Input.GetMouseButtonDown(1))
        {
            playerFSM.Grenade();
        }


    }

    void KeyboardInput()
    {

        fHor = Input.GetAxis("Horizontal");
        fVer = Input.GetAxis("Vertical");
        
        // runMode
        // 달릴 때는 앞뒤좌우로 다 이동 가능함!!

        //Vector3 runMode = moveDir.normalized;
        //transform.forward = runMode;

        //walkMode
        //걸을 때는 앞으로만 걸을 수 있음
        // 옆, 뒤는 다른 모션으로 모션을 다르게할 거임
        
        if (fHor != 0 || fVer != 0)
        {
            moveDir = lookForward * fVer + lookRight * fHor;

            body.forward = lookForward;

            playerFSM.MoveTo(fVer,fHor);

            transform.position += moveDir * Time.deltaTime * 5f;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //playerFSM.Jump();
        }

        if(Input.GetKeyDown(KeyCode.LeftCommand))
        {
            
            EnterMouseMode();
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            EnterMouseMode();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(GameManager.GetInstance.MoveMode == 0)
                GameManager.GetInstance.MoveMode = 1;
            else
                GameManager.GetInstance.MoveMode = 0;

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            playerFSM.Reload();
        }

    }



}
