using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPointGizmo : MonoBehaviour
{
    public Transform BulletPoint;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(BulletPoint.position, 0.01f);

        Debug.DrawRay(BulletPoint.position, BulletPoint.forward*100f, Color.yellow);
    }
}
