using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public Transform target;
    public Vector3 relativeVec;

    public Animator anim;
    private Transform spine;

    bool animMode = false;

    public Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spine = anim.GetBoneTransform(HumanBodyBones.Spine);

    }

    private void LateUpdate()
    {
        
        spine.LookAt(target.position);
        spine.rotation *= Quaternion.Euler(relativeVec);
    }

    


}
