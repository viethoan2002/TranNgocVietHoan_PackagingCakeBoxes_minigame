using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupLose : BasePopup
{
    [SerializeField] private Button btnHome, btnReset;

    private void Awake()
    {
        btnHome.onClick.AddListener(ShowHome);
        btnReset.onClick.AddListener(ResetGame);
    }

    private void ShowHome()
    {
        HideImmediately(false);
        PopupController.instance.popupLevel.ShowImmediately(false, null);
    }

    private void ResetGame()
    {
        HideImmediately(false);
        GameController.instance.ResetLevel();
    }
}
