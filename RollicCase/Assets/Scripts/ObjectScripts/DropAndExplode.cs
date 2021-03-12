using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAndExplode : MonoBehaviour
{
    Rigidbody rb;
    GameObject collector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collector = GameObject.Find("collector");
    }

    void Update()
    {
        if (transform.position.z - collector.transform.position.z < 30f)
        {
            rb.isKinematic = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            for (; transform.childCount > 0;)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).transform.parent=null;
            }
            Destroy(gameObject);
        }
    }
}
