using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController instance;
    public List<LevelData> lsData = new List<LevelData>();

    private void Awake()
    {
        instance = this;
        LoadDataFromPref();
    }

    public void LoadDataFromPref()
    {
        UserData.SetLevelLock(0, false);

        for(int i = 0; i < lsData.Count; i++)
        {
            lsData[i].isLock = UserData.GetLevelLock(i);
            lsData[i].starLevel = UserData.GetLevelStar(i);
        }
    }
}
