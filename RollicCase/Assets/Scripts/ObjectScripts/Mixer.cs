using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    public int speed;
    GameObject collector;
    bool levelMoving = false;

    void Start()
    {
        collector = GameObject.Find("collector");
    }

    void Update()
    {
        if (transform.position.z - collector.transform.position.z < 15f && !levelMoving)
        {
            levelMoving = true;
        }
        if (levelMoving)
        {
            if (transform.localPosition.z < 160f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.position = transform.position + new Vector3(Mathf.Sin(transform.position.z / 2) / 12, 0, 0);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}