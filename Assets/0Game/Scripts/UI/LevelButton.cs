using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private List<StarCtrl> stars = new List<StarCtrl>();

    [SerializeField] private Image imgLock;
    [SerializeField] private Text txtLevel;

    public void AddListaner(Action action)
    {
        btn.onClick.AddListener(() =>
        {
            action?.Invoke();
        });
    }

    public void SetBtn(LevelData data)
    {
        foreach (var star in stars)
        {
            star.ShowStar(false);
        }

        if (data.isLock)
        {
            txtLevel.enabled = false;
            imgLock.enabled = true;
        }
        else
        {
            txtLevel.enabled = true;
            txtLevel.text = (data.indexLevel + 1).ToString();
            imgLock.enabled = false;

            for(int i = 0; i < data.starLevel; i++)
            {
                stars[i].ShowStar(true);
            }
        }
    }
}
