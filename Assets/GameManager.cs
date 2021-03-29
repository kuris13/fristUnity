using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager Instance = null;

    public static GameManager GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new GameManager();
            return Instance;
        }
    }

    public bool MouseMode = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
