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

    GameObject curEnemy;

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

    public bool IsMove()
    {
        if(currentState == State.Move)
            return true;

        return false;
    }

    public void AttackEnemy(GameObject enemy)
    {
        if(curEnemy != null && curEnemy == enemy)
        {
            return;
        }

        curEnemy = enemy;

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
        if (CoolTimeTimer > GlobalCoolTime)
        {
            curSkillNum = SkillNum;
            ChangeState(State.AttackBlend, PlayerAni.ANI_ATTACKBLEND);
            CoolTimeTimer = 0f;
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
        Move();

        fVer = 0f;
        fHor = 0f;
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

    public void TurnTo(float _fHor)
    {
        fHor = _fHor;
        Turn();
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
