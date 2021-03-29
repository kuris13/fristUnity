using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float fHor;

    public float Speed;

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        Speed = 2f;
    }

    private void Update()
    {
        KeyboardInput();
        if(!GameManager.GetInstance.MouseMode)
            MouseInput();
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

        if(fVer != 0)
        {
            GetComponent<PlayerFSM>().MoveTo(fVer);
        }
        if (fHor != 0)
            GetComponent<PlayerFSM>().TurnTo(fHor);

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
