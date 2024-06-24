using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupLevel : BasePopup
{
    [SerializeField] private Button _btnBack;
    [SerializeField] private List<LevelButton> btnLv = new List<LevelButton>();
    private void Awake()
    {
        _btnBack.onClick.AddListener(ShowHome);
        for(int i = 0; i < DataController.instance.lsData.Count; i++)
        {
            btnLv[i].gameObject.SetActive(true);

            int indexLV = i;
            btnLv[i].AddListaner(() =>
            {
                if (!DataController.instance.lsData[indexLV].isLock)
                {
                    GameController.instance.LoadLevel(indexLV);
                    HideImmediately(false);
                    PopupController.instance.popupGameplay.ShowImmediately(true, null);
                }

            });
        }
    }

    public override void ShowImmediately(bool showImmediately, Action actionComplete = null)
    {
        base.ShowImmediately(showImmediately, actionComplete);
        SetAllBtn();
    }

    public void SetAllBtn()
    {
        for(int i = 0; i < DataController.instance.lsData.Count; i++)
        {
            btnLv[i].SetBtn(DataController.instance.lsData[i]);
        }
    }

    private void ShowHome()
    {
        HideImmediately(false);
        PopupController.instance.popupHome.ShowImmediately(true, null);
    }
}
