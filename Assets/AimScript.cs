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

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        spine = anim.GetBoneTransform(HumanBodyBones.Spine);
    }

    private void LateUpdate()
    {
        target = GameManager.GetInstance.AimTarget;
        spine.LookAt(new Vector3(target.position.x, target.position.y, target.position.z)  );
        spine.rotation *= Quaternion.Euler(new Vector3(10f,20f,0f));
    }

    


}
