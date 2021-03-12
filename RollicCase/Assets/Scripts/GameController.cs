using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] levelParts;
    public GameObject touchToStartCanvas;
    public GameObject restartButton;
    public Image[] levelProgress;

    public Sprite partDone;

    public float speed;
    public bool levelMoving = false;
    bool initialTouch = true;

    Touch touch;

    //Rigidbody rb;
    
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.touchCount>0) && initialTouch)
        {
            levelMoving = true;
            initialTouch = false;
            touchToStartCanvas.SetActive(false);
        }
        if (levelMoving)
        {
            /*foreach (GameObject part in levelParts)
            {
                part.transform.Translate(Vector3.back * Time.deltaTime * speed);
            }*/
            //rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * speed);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved && Mathf.Abs(transform.position.x + touch.deltaPosition.x * Time.deltaTime)<=2.3f)
            {
                Vector3 xAxis = new Vector3(touch.deltaPosition.x * Time.deltaTime, 0, 0);
                //rb.position =transform.position + xAxis;
                transform.position = transform.position + xAxis;
            }
        }
    }
}
