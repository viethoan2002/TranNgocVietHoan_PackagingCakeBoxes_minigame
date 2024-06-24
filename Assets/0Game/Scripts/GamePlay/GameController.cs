using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private LevelData curData;
    private int curIndex;
    public Camera cam;

    public bool onPlay;
    [SerializeField] private float _timePlay;
    [SerializeField] private float currentTime;

    private void Awake()
    {
        instance = this;
    }

    public void LoadLevel(int indexLevel)
    {
        curIndex = indexLevel;
        curData = DataController.instance.lsData[indexLevel];
        LoadFromPool();
        
        onPlay = true;
        currentTime = _timePlay;
        StartCoroutine(PlayTime());
    }

    public void NextLevel()
    {
        if (curIndex < DataController.instance.lsData.Count - 1)
            curIndex += 1;
  
        curData = DataController.instance.lsData[curIndex];
        LoadFromPool();

        onPlay = true;
        currentTime = _timePlay;
        StartCoroutine(PlayTime());
    }

    public void LoadFromPool()
    {
        ObjectPool.Instance.ReturnAllPool();

        var map = ObjectPool.Instance.Get(ObjectPool.Instance.CheckAddPool(curData.prefLevel));

        for (int i = 0; i < curData.cakePos.Count; i++)
        {
            var cake = ObjectPool.Instance.Get(ObjectPool.Instance.cake);
            cake.GetComponent<CakeCtrl>().box = null;
            cake.transform.position = curData.cakePos[i];
        }

        for (int i = 0; i < curData.candyPos.Count; i++)
        {
            var candy = ObjectPool.Instance.Get(ObjectPool.Instance.candy);
            candy.transform.position = curData.candyPos[i];
        }

        for (int i = 0; i < curData.boxPos.Count; i++)
        {
            var box = ObjectPool.Instance.Get(ObjectPool.Instance.box);
            box.GetComponent<BoxCtrl>().cake = null;
            box.transform.position = curData.boxPos[i];
        }
    }

    public void ResetLevel()
    {
        LoadFromPool();
        onPlay = true;
        currentTime = _timePlay;
        StartCoroutine(PlayTime());
    }

    public void ResetTime()
    {
        LoadFromPool();
        currentTime = _timePlay;
    }

    IEnumerator PlayTime()
    {
        while (onPlay)
        {
            currentTime -= Time.deltaTime;
            PopupController.instance.popupGameplay.UpdateTime(currentTime);
            if (currentTime < 0)
            {
                onPlay = false;
                CheckWin();
            }
            yield return null;
        }
    }

    public void CheckWin()
    {
        if (currentTime > 0)
        {
            //Win
            UserData.SetLevelLock(curData.indexLevel + 1, false);

            PopupController.instance.popupWin.ShowImmediately(true, null);
            if (currentTime > 0.66f * _timePlay)
            {
                PopupController.instance.popupWin.ShowStar(3);
                UserData.SetLevelStar(curData.indexLevel, 3);

            }else if (currentTime > 0.33f * _timePlay)
            {
                PopupController.instance.popupWin.ShowStar(2);
                UserData.SetLevelStar(curData.indexLevel,2);
            }else if (currentTime > 0f * _timePlay)
            {
                PopupController.instance.popupWin.ShowStar(1);
                UserData.SetLevelStar(curData.indexLevel,1);
            }

            DataController.instance.LoadDataFromPref();
        }
        else
        {
            //Lose
            currentTime = 0;
            PopupController.instance.popupGameplay.UpdateTime(currentTime);
            PopupController.instance.popupLose.ShowImmediately(true, null);
        }
    }

    private void Update()
    {
        
    }
}
