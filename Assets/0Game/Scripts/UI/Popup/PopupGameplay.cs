using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGameplay : BasePopup
{
    [SerializeField] private Button btnHome, btnReset;
    [SerializeField] private Text txtTime;

    private void Awake()
    {
        btnHome.onClick.AddListener(ShowHome);
        btnReset.onClick.AddListener(ResetLevel);
    }

    private void ShowHome()
    {
        GameController.instance.onPlay = false;

        HideImmediately(false);
        PopupController.instance.popupLevel.ShowImmediately(false, null);
    }

    private void ResetLevel()
    {
        GameController.instance.ResetTime();
    }

    public void UpdateTime(float time)
    {
        txtTime.text = time.ToString("00.00");
    }
}
