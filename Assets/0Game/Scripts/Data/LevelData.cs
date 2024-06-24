using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level")]
public class LevelData : ScriptableObject
{
    public int indexLevel;
    public bool isLock;
    public int starLevel;
    public GameObject prefLevel;

    public List<Vector3> cakePos;
    public List<Vector3> candyPos;
    public List<Vector3> boxPos;
}
