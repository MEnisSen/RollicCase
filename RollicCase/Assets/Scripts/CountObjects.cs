using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountObjects : MonoBehaviour
{
    public int objectCount = 0;
    public Text countText;
    public int neededAmount=0;
    public int counterNumber;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Objects")
        {
            Destroy(other.gameObject);
            objectCount++;
            countText.text = "" + objectCount + " - " + neededAmount;
        }
    }
}
