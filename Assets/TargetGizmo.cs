﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
