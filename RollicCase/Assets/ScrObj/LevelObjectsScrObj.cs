using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelObjectsScrObj", order = 1)]
public class LevelObjectsScrObj : ScriptableObject
{
    public string objName;

    public GameObject objects;
    public int howManyToPass;
}