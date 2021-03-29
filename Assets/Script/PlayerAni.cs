using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    public const int ANI_IDLE = 0;
    public const int ANI_WALK = 1;
    public const int ANI_ATTACKBLEND = 2;
    public const int ANI_ATKIDLE = 3;
    public const int ANI_DIE = 4;
    public const int ANI_JUMP = 5;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeAni(int aniNum)
    {
        anim.SetInteger("aniName", aniNum);
    }

    public void ChangeAni(int aniNum, float Blend)
    {
        anim.SetInteger("aniName", aniNum);
        anim.SetFloat("Blend", Blend);
    }

    
    public bool AttackToAttakWait()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("attackB") &&
            0.1f < anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    public bool JumpToIdle()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("jump") &&
            0.1f < anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
