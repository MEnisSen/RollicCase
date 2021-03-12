using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStop : MonoBehaviour
{
    public GameObject countCanvas;
    public GameObject counterObj;
    public int counterNumber;
    public int need;
    GameObject collector;
    public GameObject RestartButton;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            need = other.transform.GetComponent<LevelPrepare>().howManyNeededToPass[counterNumber-1];
            counterObj.transform.GetComponent<CountObjects>().neededAmount = need;
            // Temporary Line (Just to make sure its working...)
            counterObj.transform.GetComponent<CountObjects>().countText.text = "" + 0 + " - " + need;
            // ------------------------------------------

            countCanvas.SetActive(true);
            other.transform.GetComponent<GameController>().levelMoving = false;
            
            StartCoroutine(CountObjectsCo());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            countCanvas.SetActive(false);
        }
    }

    IEnumerator CountObjectsCo()
    {
        yield return new WaitForSeconds(5.0f);
        collector = GameObject.Find("collector").gameObject;
        if (counterObj.transform.GetComponent<CountObjects>().objectCount < need)
        {
            RestartButton.SetActive(true);
        }
        else
        {
            collector.transform.GetComponent<GameController>().levelProgress[counterNumber - 1].sprite = collector.transform.GetComponent<GameController>().partDone;
            collector.transform.GetComponent<GameController>().levelMoving = true;
        }
    }
}