using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_2 : MonoBehaviour
{

    [SerializeField]
    Transform elbow;
    [SerializeField]
    Transform elbowBone;

    [SerializeField]
    Transform shoulder;
    [SerializeField]
    Transform shoulderBone;

    [SerializeField]
    Transform hand;

    [SerializeField]
    Transform target;

    private Vector3 lastTargetPos;

    private float elbowBoneLength;
    private float shoulderBoneLength;

    // Start is called before the first frame update
    void Start()
    {
        lastTargetPos = target.position;
        
        // BONE 1
        elbowBoneLength = Vector2.Distance(new Vector2(elbow.position.y, elbow.position.z), new Vector2(hand.position.y, hand.position.z));

        // BONE 2
        shoulderBoneLength = Vector2.Distance(new Vector2(shoulder.position.y, shoulder.position.z), new Vector2(elbow.position.y, elbow.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTargetPos != target.position){
            float r = Vector2.Distance(new Vector2(shoulder.position.y, shoulder.position.z), 
            new Vector2(target.position.y, target.position.z));

            if(r <= elbowBoneLength + shoulderBoneLength){
                float cos_beta = ((r * r) + (shoulderBoneLength * shoulderBoneLength) - 
                (elbowBoneLength * elbowBoneLength)) / (2 * r * shoulderBoneLength);

                float beta = Mathf.Acos(cos_beta) * Mathf.Rad2Deg;

                float cos_alpha = ((elbowBoneLength * elbowBoneLength) + (shoulderBoneLength * shoulderBoneLength) - (r * r)) / (2 * elbowBoneLength * shoulderBoneLength);
                float alpha = Mathf.Acos(cos_alpha) * Mathf.Rad2Deg;

                Vector2 diff = new Vector2(target.position.y, target.position.z) - 
                new Vector2(shoulder.position.y, shoulder.position.z);

                float gamma = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

                float q1 = gamma + beta - 90f;
                float q2 = 180f - alpha;

                shoulder.localRotation = Quaternion.Euler(q1, 90f, 0f);
                elbow.localRotation = Quaternion.Euler(-q2, 0f, 0f);

            } else{
                shoulder.LookAt(target);
                elbow.LookAt(target);
            }
        }
    }
}
