using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //retrO code
    public string moveHorizontalAxisName = "Horizontal";
    public string moveVerticalAxisName = "Vertical";

    public string fireButtonName = "Fire1";
    public string jumpButtonName = "Jump";
    public string reloadButtonName = "Reload";


    // 값 할당은 내부에서만 가능
    public Vector2 moveInput { get; private set; }
    public bool fire { get; private set; }
    public bool reload { get; private set; }
    public bool jump { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        /*
        // 게임오버 상태인지 확인
        if(GameManager.GetInstance.isGameover)
        {
            moveInput = Vector2.zero;
            fire = false;
            reload = false;
            jump = false;
            
            return;
        }

         */
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis(moveVerticalAxisName));

        if (moveInput.sqrMagnitude > 1) moveInput = moveInput.normalized;

        jump = Input.GetButtonDown(jumpButtonName);
        fire = Input.GetButton(fireButtonName);
        reload = Input.GetButtonDown(reloadButtonName);
        //Debug.Log("playerInput작동중");
    }
}
