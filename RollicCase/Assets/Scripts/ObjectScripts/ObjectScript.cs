using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            transform.parent = null;         
            Destroy(this);
        }
    }
}
