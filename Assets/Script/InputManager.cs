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
    }

    void KeyboardInput()
    {
        fHor = Input.GetAxis("Horizontal");
        float fVer = Input.GetAxis("Vertical");
        /*
        if(fVer != 0)
        {
            GetComponent<PlayerFSM>().MoveTo(fVer);
        }
        */
        //손을 누르거나 땟을 때
        if (fVer < 1f && fVer > -1f && fVer != 0f)
        {
            //내가 이미 움직이는 중이 아니라면 -> 바로 무브시켜야함
            if(!GetComponent<PlayerFSM>().IsMove())
                GetComponent<PlayerFSM>().MoveTo(fVer);
            //움직이는 중이라면 -> 무브 시키지 말아야함 
            else if(GetComponent<PlayerFSM>().IsMove())
            {
                //GetComponent<PlayerFSM>().MoveStop();
            }
        }

       if(fVer == 1f || fVer == -1f)
        {
            GetComponent<PlayerFSM>().MoveTo(fVer);
        }
         


        if (fHor != 0)
            GetComponent<PlayerFSM>().TurnTo(fHor);

    }
}
