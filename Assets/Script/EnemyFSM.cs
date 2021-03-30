using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{

    public enum State
    {
        Idle,
        Chase,
        Attack,
        Dead,
        NoState
    }

    public State currentState = State.Idle;

    EnemyAni myAni;

    Transform player;

    float chaseDistacne = 5f;
    float attackDistance = 2.5f;
    float reChaseDistance = 3f;

    //float rotAnglePerSecond = 360f;
    //float moveSpeed = 1.3f;

    float attackDelay = 2f;
    float attackTimer = 0f;

    private void Awake()
    {
        myAni = GetComponent<EnemyAni>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(State.Idle, EnemyAni.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    void UpdateState()
    {
        switch(currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Chase:
                ChaseState();
                break;
            case State.Attack:
                AttackState();
                break;
            case State.Dead:
                DeadState();
                break;
            case State.NoState:
                NoState();
                break;
        }
    }

    public void ChangeState(State newState, string aniName)
    {
        if(currentState == newState)    
            return;

        currentState = newState;
        myAni.ChangeAni(aniName);
    }

    void IdleState()
    {
        if(GetDistanceFromPlayer() < chaseDistacne)
        {
            ChangeState(State.Chase, EnemyAni.WALK);
        }
    }

    void ChaseState()
    {
        if(GetDistanceFromPlayer() < attackDistance)
        {
            ChangeState(State.Attack, EnemyAni.ATTACK);
        }
        else
        {
            //이동하는 함수 ->  navi 추가시 작동
        }
    }

    void AttackState()
    {
        if(GetDistanceFromPlayer() > reChaseDistance)
        {
            attackTimer = 0f;
            ChangeState(State.Chase, EnemyAni.WALK);
        }
        else
        {
            if(attackTimer > attackDelay)
            {
                transform.LookAt(player.position);
                myAni.ChangeAni(EnemyAni.ATTACK);

                attackTimer = 0f;
            }
        }

        attackTimer += Time.deltaTime;
    }

    void NoState()
    {

    }

    void DeadState()
    {

    }

    float GetDistanceFromPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance;
    }

}
