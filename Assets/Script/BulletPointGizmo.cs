using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPointGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.01f);

        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
    }
}
