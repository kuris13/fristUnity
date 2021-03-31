using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager 
{
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        get
        {
            if(Instance == null)
            {
                Instance = new ObjectManager();
            }
            return Instance;
        }
    }

    private List<GameObject> EnableEnemyList = new List<GameObject>();
    public List<GameObject> GetEnableEnemyList
    {
        get
        {
            return EnableEnemyList;
        }
    }

    private Stack<GameObject> DisableLEnemyList = new Stack<GameObject>();
    public Stack<GameObject> GetDisableEnemyList
    {
        get
        {
            return DisableLEnemyList;
        }
    }

}
