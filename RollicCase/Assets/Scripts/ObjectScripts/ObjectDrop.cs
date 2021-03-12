using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrop : MonoBehaviour
{
    public int speed;
    bool initialTouch = true;
    bool levelMoving = false;

    GameObject collector;

    void Start()
    {
        InvokeRepeating("DropObject", 0f, 0.2f);
        collector = GameObject.Find("collector");
    }

    void Update()
    {
        if (transform.position.z - collector.transform.position.z < 20f && initialTouch)
        {
            levelMoving = true;
            initialTouch = false;
        }
        if (levelMoving)
        {
            if (transform.localPosition.z < 160f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.position = transform.position + new Vector3(Mathf.Sin(transform.position.z/2)/12,0,0);
            }
            else
            {
                Destroy(gameObject);
            }     
        }
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    public void DropObject()
    {
        if (levelMoving)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).transform.parent = null;
        }
    }
}