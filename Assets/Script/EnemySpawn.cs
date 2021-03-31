using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public int EnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCount = 0;
        
        if(ObjectManager.GetInstance.GetDisableEnemyList.Count == 0)
        {
            for(int i =0; i < 10; i++)
            {
                GameObject temp = Instantiate(EnemyPrefab);

                temp.name = EnemyCount.ToString();

                EnemyCount++;

                temp.SetActive(false);

                ObjectManager.GetInstance.GetDisableEnemyList.Push(temp);
            }
        }


        MakeEnemy(5);

    }

    public void MakeEnemy(int num)
    {
        for(int i =0;i<num;i++)
        {
            GameObject obj = ObjectManager.GetInstance.GetDisableEnemyList.Pop();
            obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + i * 2);

            obj.SetActive(true);

            ObjectManager.GetInstance.GetEnableEnemyList.Add(obj);
        }
    }

    private void Update()
    {
        //Destroy(gameObject);
    }
}
