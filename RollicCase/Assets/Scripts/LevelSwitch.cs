using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerPrefs.SetInt("CurrentLevel", other.transform.GetComponent<LevelPrepare>().currentLevel + 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameScene");
        }
    }
}
