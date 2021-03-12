using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject player;

    Vector3 camFollowVec;

    void Start()
    {
        camFollowVec = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, (player.transform.position.y + camFollowVec.y), (player.transform.position.z + camFollowVec.z));
    }
}
