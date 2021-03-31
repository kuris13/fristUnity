using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward);
    }
}
