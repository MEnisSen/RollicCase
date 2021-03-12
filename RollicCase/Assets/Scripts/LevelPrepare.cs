using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPrepare : MonoBehaviour
{
    public Text currentLevelText;
    public Text nextLevelText;

    public Image[] levelProgress;

    public int currentLevel;

    public LevelObjectsScrObj[] smallLevelScr;
    public GameObject[] LevelParts;

    public int[] howManyNeededToPass=new int[6]; 

    void Awake()
    {
        currentLevel=PlayerPrefs.GetInt("CurrentLevel", 1);
        currentLevelText.text = "" + currentLevel;
        nextLevelText.text = "" + (currentLevel + 1);
        //PlayerPrefs.DeleteKey("CurrentLevel");
    }

    void Start()
    {
        int i = 0;
        if (currentLevel <= 2)
        {
            foreach (GameObject part in LevelParts)
            {
                GameObject obj = Instantiate(smallLevelScr[currentLevel - 1 + i].objects, LevelParts[i].transform.position, Quaternion.identity);
                obj.transform.parent = LevelParts[i].transform;
                howManyNeededToPass[i] = smallLevelScr[currentLevel - 1 + i].howManyToPass;
                i++;
            }
        }
        else
        {
            foreach (GameObject part in LevelParts)
            {
                int randLvlInd = Random.Range(0, 5);
                GameObject obj = Instantiate(smallLevelScr[randLvlInd].objects, LevelParts[i].transform.position, Quaternion.identity);
                obj.transform.parent = LevelParts[i].transform;
                howManyNeededToPass[i] = smallLevelScr[randLvlInd].howManyToPass;
                i++;
            }
        }
    }
}
