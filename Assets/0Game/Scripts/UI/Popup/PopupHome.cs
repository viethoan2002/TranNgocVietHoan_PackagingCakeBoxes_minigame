using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupHome : BasePopup
{
    [SerializeField] private Button btnPlay, btnGuid;

    private void Awake()
    {
        btnPlay.onClick.AddListener(ShowGame);
        btnGuid.onClick.AddListener(ShowGuid);
    }

    private void ShowGame()
    {
        HideImmediately(false);
        PopupController.instance.popupLevel.ShowImmediately(false, null);
    }

    private void ShowGuid()
    {
        HideImmediately(false);
        PopupController.instance.popupGuid.ShowImmediately(true, null);
    }
}
