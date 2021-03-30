using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        AttackBlend,
        AttackWait,
        Dead,
        Jump
    }

    //idle을 기본상태로 지정
    public State currentState = State.Idle;

    PlayerAni myAni;

    Vector3 curTargetPos;

    public float moveSpeed = 2f;

    public float fHor;
    public float fVer;

    public float GlobalCoolTime = 2f;

    public float CoolTimeTimer = 0f;

    public float AttackWaitEndTime = 2f;

    public int currentAtkNum;

    public float curSkillNum;

    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<PlayerAni>();
        ChangeState(State.Idle, PlayerAni.ANI_IDLE);
    }

    // Update is called once per frame
    void UpdateState()
    {
        CoolTimeTimer += Time.deltaTime;

        switch (currentState)
        {
            case State.Idle:
                break;
            case State.Move:
                MoveState();
                break;
            case State.AttackBlend:
                AttackState();
                break;
            case State.AttackWait:
                AttackWait();
                break;
            case State.Dead:
                break;
            case State.Jump:
                JumpState();
                break;
            default:
                break;
        }
    }

    public void AttackEnemy(GameObject enemy)
    {
        
    }

    public bool IsMove()
    {
        if(currentState == State.Move)
            return true;

        return false;
    }

   

    void ChangeState(State newState, int aniNum)
    {
        if(newState == State.AttackBlend)
        {
            myAni.ChangeAni(aniNum,curSkillNum);
            currentState = newState;
        }
        else
        {
            if (currentState == newState)
                return;

            myAni.ChangeAni(aniNum);
            currentState = newState;
        }
    }

    void JumpState()
    {
        // 공격 애니메이션이 최소한 실행은 됬는가?
        if (myAni.JumpToIdle())
        {
            if (AttackWaitEndTime > 0)
                ChangeState(State.AttackWait, PlayerAni.ANI_ATKIDLE);
            else
                ChangeState(State.Idle, PlayerAni.ANI_IDLE);
        }
    }
    public void Jump()
    {
        ChangeState(State.Jump, PlayerAni.ANI_JUMP);
    }

    public void Attack(int SkillNum)
    {
        // 임시로 하드코딩해서 사용
        // CoolTimeTimer가 2보다 클 때만 공격 모션이 나감

        if (GameManager.GetInstance.curTarget != null && GameManager.GetInstance.curTarget.tag == "Enemy")
        {
            return;
        }

        curTargetPos = GameManager.GetInstance.curTarget.transform.position;

        if (CoolTimeTimer > GlobalCoolTime)
        {
            switch(SkillNum)
            {
                case 0:
                    Debug.DrawLine(curTargetPos, transform.position, Color.yellow,1f);
                    if (Vector3.Distance(curTargetPos,transform.position) < 1.5f)
                    {
                        curSkillNum = SkillNum;
                        ChangeState(State.AttackBlend, PlayerAni.ANI_ATTACKBLEND);
                        CoolTimeTimer = 0f;
                    }
                    else
                    {
                        Debug.Log("거리가 너무 멉니다!!");
                    }
                    break;
                case 1:
                    curSkillNum = SkillNum;
                    ChangeState(State.AttackBlend, PlayerAni.ANI_ATTACKBLEND);
                    CoolTimeTimer = 0f;
                    break;
                default:
                    break;
            }

            
        }
    }

    void AttackState()
    {
        // 공격 애니메이션이 최소한 실행은 됬는가?
        if(myAni.AttackToAttakWait())
        {
            ChangeState(State.AttackWait, PlayerAni.ANI_ATKIDLE);
            AttackWaitEndTime = 2f;
        }
    }

    void AttackWait()
    {
        AttackWaitEndTime -= Time.deltaTime;
        if(AttackWaitEndTime < 0)
        {
            ChangeState(State.Idle, PlayerAni.ANI_IDLE);
        }
    }

    void MoveState()
    {
        MoveStop();

        fVer = 0f;
        fHor = 0f;
    }

    public void MoveTo(float _fVer, float _fHor)
    {
        
        fVer = _fVer;
        fHor = _fHor;

        ChangeState(State.Move, PlayerAni.ANI_WALK);


    }

    void MoveStop()
    {
        if (currentState == State.Move &&
            fVer == 0 &&
            fHor == 0) 
        {
            ChangeState(State.Idle, PlayerAni.ANI_IDLE);
        }
    }

    

    private void Update()
    {
        UpdateState();
    }

}
