using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y +1.46f, transform.position.z), 0.1f);
    }
}
