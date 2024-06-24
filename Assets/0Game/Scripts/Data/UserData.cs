using UnityEngine;

public static class UserData
{
    public static void SetLevelLock(int index,bool value)
    {
        PlayerPrefs.SetInt($"level_{index}_lock", value ? 1 : 0);
    }

    public static bool GetLevelLock(int index)
    {
        return PlayerPrefs.GetInt($"level_{index}_lock", 1) == 1;
    }

    public static void SetLevelStar(int index, int value)
    {
        PlayerPrefs.SetInt($"level_{index}_star", value);
    }

    public static int GetLevelStar(int index)
    {
        return PlayerPrefs.GetInt($"level_{index}_star", 0);
    }
}
