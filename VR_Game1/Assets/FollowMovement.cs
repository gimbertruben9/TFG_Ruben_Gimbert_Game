using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{
    public Transform headset;
    public Transform body;
    // Start is called before the first frame update
    void Start()
    {
        body.position = headset.position;
        body.rotation = headset.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        body.position = headset.position;
        body.rotation = headset.rotation;
    }
}
