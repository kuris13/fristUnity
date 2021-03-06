using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager Instance;

    public static GameManager GetInstance
    {
        get
        {
            if (!Instance)
            {
               Instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (Instance == null)
                    Debug.Log("no Singleton obj");
            }
            return Instance;
        }
    }
    public bool isGameover = false;
    public bool MouseMode = false;
    public GameObject curTarget =null;
    public int MoveMode = 0;
    public Transform AimTarget;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    
    
}
