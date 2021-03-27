using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{



    public enum State
    {
        Idle,
        Move,
        Attack,
        AttackWait,
        Dead
    }


    //idle을 기본상태로 지정
    public State currentState = State.Idle;

    PlayerAni myAni;

    public float moveSpeed = 2f;

    public float fHor;
    public float fVer;

    public bool IsMove()
    {
        if(currentState == State.Move)
            return true;

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<PlayerAni>();
        ChangeState(State.Idle, PlayerAni.ANI_IDLE);
    }

    void ChangeState(State newState, int aniNum)
    {
        if (currentState == newState)
            return;

        myAni.ChangeAni(aniNum);
        currentState = newState;
    }

    // Update is called once per frame
    void UpdateState()
    {
        switch(currentState)
        {
            case State.Idle:
                break;
            case State.Move:
                Move();
                
                fVer = 0f;
                fHor = 0f;
                
                break;
            case State.Attack:
                break;
            case State.AttackWait:
                break;
            case State.Dead:
                break;
            default:
                break;
        }
    }

    public void MoveStop()
    {
        ChangeState(State.Idle, PlayerAni.ANI_IDLE);
        fVer = 0;
    }

    public void MoveTo(float _fVer)
    {
        
        fVer = _fVer;

        ChangeState(State.Move, PlayerAni.ANI_WALK);


    }

    public void TurnTo(float _fHor)
    {
        fHor = _fHor;
        Turn();
    }

    void Move()
    {
        transform.Translate(
          0f,
          0f,
          fVer * Time.deltaTime * moveSpeed);

        if (currentState == State.Move &&
            fVer == 0) 
        {
            ChangeState(State.Idle, PlayerAni.ANI_IDLE);
        }
    }

    void Turn()
    {
        Vector3 angle = transform.rotation.eulerAngles;
        angle.y += Time.deltaTime * fHor * 120;

        transform.rotation = Quaternion.Euler(angle);
    }

    private void Update()
    {
        UpdateState();
    }

}
