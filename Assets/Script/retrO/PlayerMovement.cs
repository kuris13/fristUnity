using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    //private PlayerShooter playerShooter;
    private Animator animator;

    public Camera followCam;

    public float speed = 6;
    public float jumpVelocity = 20f;
    [Range(0.01f, 1f)] public float airControlPercent;

    public float speedSmoothTime = 0.1f;
    public float turnSmmothTime = 0.1f;

    private float speedSmoothVelocity;
    private float turnSmoothVelocity;

    private float currentVelocityY;

    public float currentSpeed => new Vector2(
        characterController.velocity.x,
        characterController.velocity.z).magnitude;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
  
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (currentSpeed > 0.2f || playerInput.fire) Rotate();

        Move(playerInput.moveInput);

        if (playerInput.jump) Jump();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation(playerInput.moveInput);
        //Debug.Log("playerMovement작동중");
    }

    public void Move(Vector2 moveInput)
    {
        var targetSpeed = speed * moveInput.magnitude;
        var moveDirection = Vector3.Normalize(
            transform.forward * moveInput.y
            + transform.right * moveInput.x);

        var smoothTime = characterController.isGrounded ? speedSmoothTime : speedSmoothTime / airControlPercent;

        targetSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, smoothTime);
        currentVelocityY += Time.deltaTime * Physics.gravity.y;

        var velocity = moveDirection * targetSpeed + Vector3.up * currentVelocityY;

        characterController.Move(velocity * Time.deltaTime);


        if (characterController.isGrounded) currentVelocityY = 0;
    }

    public void Rotate()
    {
        var targetRotation = followCam.transform.eulerAngles.y;

        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(
            transform.eulerAngles.y,
            targetRotation,
            ref turnSmoothVelocity,
            turnSmmothTime);

    }

    public void Jump()
    {
        if (!characterController.isGrounded) return;
        currentVelocityY = jumpVelocity;
    }

    private void UpdateAnimation(Vector2 moveInput)
    {
        var animationSpeedPercent = currentSpeed / speed;

        animator.SetFloat("Horizontal", moveInput.x * animationSpeedPercent, 0.05f, Time.deltaTime);
        animator.SetFloat("Vertical", moveInput.y * animationSpeedPercent, 0.05f, Time.deltaTime);


    }

}
