using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager Instance = null;

    public static UIManager GetInstance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new UIManager();
            }
            return Instance;
        }
    }
}
