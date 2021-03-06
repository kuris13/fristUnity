using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    public const int ANI_IDLE = 0;
    public const int ANI_WALK = 1;
    public const int ANI_SHOT = 2;
    public const int ANI_ATKIDLE = 3;
    public const int ANI_DIE = 4;
    public const int ANI_GRENADE = 5;
    public const int ANI_RELOAD = 6;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeAni(int aniNum)
    {
        //anim.SetInteger("aniName", aniNum);
    }
    public void ChangeAniShot(bool Shot)
    {
        anim.SetBool("ShotBool", Shot);
    }
    public void ChangeAniGrenade()
    {
        anim.SetTrigger("Grenade");
    }
    public void ChangeAniReload()
    {
        anim.SetTrigger("Reload");
    }

    public void ChangeAniMove(float fHor, float fVer)
    {
        float offset = 0.5f + GameManager.GetInstance.MoveMode * 0.5f;
        anim.SetFloat("Horizontal", fHor * offset);
        anim.SetFloat("Vertical", fVer * offset);
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
