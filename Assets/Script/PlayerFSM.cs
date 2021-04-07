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
        Dead,
        Jump
    }

    #region Var
    //idle을 기본상태로 지정
    public State currentState = State.Idle;

    PlayerAni myAni;

    Vector3 curTargetPos;

    public GameObject BulletPrefab;
    public Transform BulletTransform;
    public float moveSpeed = 2f;

    public float fHor;
    public float fVer;

    public float GlobalCoolTime = 2f;

    public float CoolTimeTimer = 0f;

    public float AttackWaitEndTime = 2f;

    public int currentAtkNum;

    public int SkillNum;



    #endregion

    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<PlayerAni>();
        ChangeState(State.Idle, PlayerAni.ANI_IDLE);
    }
    private void Update()
    {
        UpdateState();
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
            case State.Attack:
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

    void ChangeState(State newState, int aniNum)
    {
        if(newState == State.Move)
        {
            myAni.ChangeAniMove(fHor,fVer);
            currentState = newState;
        }
        if (newState == State.Attack)
        {
           // myAni.ChangeAniAttack(aniNum,SkillNum);
           // currentState = newState;
        }
        else
        {
            if (currentState == newState)
                return;

            myAni.ChangeAni(aniNum);
            currentState = newState;
        }
    }

    #region AttackAutoTargeting

    //  오토 타겟팅 공격 ( 사용 X )
    /*
    //애니메이션의 이벤트로 추가될 함수
    //몬스터에게 공격을 가한다
    public void AttackCalculate()
    {
        if (GameManager.GetInstance.curTarget == null)
        {
            return;
        }

        if (!GameManager.GetInstance.curTarget.CompareTag("Enemy"))
        {
            //널이거나 적이 아니기 떄문에 공격 대상이 아니여서 공격을 안 함

            return;
        }
        GameManager.GetInstance.curTarget.GetComponent<EnemyFSM>().ShowHitEffect();
    }

    public void Attack(int SkillNum)
    {
        // 임시로 하드코딩해서 사용
        // CoolTimeTimer가 2보다 클 때만 공격 모션이 나감

        // 공격이 실행됨
        // 나의 타겟이 비어있는지 또한 에너미가 맞는지 확인함
        if (GameManager.GetInstance.curTarget == null)
        {
            return;
        }

        if (!GameManager.GetInstance.curTarget.CompareTag("Enemy"))
        {
            //널이거나 적이 아니기 떄문에 공격 대상이 아니여서 공격을 안 함

            return;
        }
        //여기부터는 공격 대상이 적임
        else
        {
            //타겟의 위치를 기억함
            curTargetPos = GameManager.GetInstance.curTarget.transform.position;

            if (CoolTimeTimer > GlobalCoolTime)
            {
                switch (SkillNum)
                {
                    case 0:
                        //1초동안 타겟의 위치와 내 위치를 선으로 보여줌
                        Debug.DrawLine(curTargetPos, transform.position, Color.yellow, 1f);
                        //만약 타겟과 나의 거리가 1.5 유니티 미터 사이라면 공격 실행
                        float enemyDistance = Vector3.Distance(curTargetPos, transform.position);

                        if (enemyDistance < 1.5f)
                        {
                            curSkillNum = SkillNum;
                            ChangeState(State.AttackBlend, PlayerAni.ANI_ATTACKBLEND);
                            CoolTimeTimer = 0f;
                        }
                        else
                        {
                            Debug.Log("거리가 너무 멉니다!! ->" + Vector3.Distance(curTargetPos, transform.position));
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


    }

    void AttackState()
    {
        // 공격 애니메이션이 최소한 실행은 됬는가?
        if (myAni.AttackToAttakWait())
        {
            ChangeState(State.AttackWait, PlayerAni.ANI_ATKIDLE);
            AttackWaitEndTime = 2f;
        }
    }

    void AttackWait()
    {
        AttackWaitEndTime -= Time.deltaTime;
        if (AttackWaitEndTime < 0)
        {
            ChangeState(State.Idle, PlayerAni.ANI_IDLE);
        }
    }
     */
    #endregion
    
    public void Shot()
    {
        
        myAni.ChangeAniShot(true);
        GameObject Bullet = Instantiate(
            BulletPrefab,
            BulletTransform.position,
            Quaternion.Euler(Vector3.zero)
            );

        Rigidbody BulletRigid = Bullet.GetComponent<Rigidbody>();
        
        //BulletRigid.AddForce();
        //총알이 타겟을 쳐다봄
        Bullet.transform.LookAt(GameManager.GetInstance.AimTarget);
        Bullet.transform.rotation *= Quaternion.Euler(new Vector3(0f, 0f, 0f));
        BulletRigid.AddForce(Bullet.transform.forward * 1000f);
    }

    public void ShotStop()
    {
        myAni.ChangeAniShot(false);
    }

    public void Grenade()
    {
        myAni.ChangeAniGrenade();
    }

    public void Reload()
    {
        myAni.ChangeAniReload();
    }

    void AttackState()
    {

    }

    void AttackWait()
    {

    }

    #region MoveAndJump
    public bool IsMove()
    {
        if (currentState == State.Move)
            return true;

        return false;
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
    
    #endregion




    

}
