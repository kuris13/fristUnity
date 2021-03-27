using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    

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
        float fHor = Input.GetAxis("Horizontal");
        float fVer = Input.GetAxis("Vertical");

        transform.Translate(
           fHor * Time.deltaTime * Speed,
           0.0f,
           fVer * Time.deltaTime * Speed);

    }
}
