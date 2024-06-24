using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGuid : BasePopup
{
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnExit.onClick.AddListener(ShowHome);
    }

    private void ShowHome()
    {
        HideImmediately(false);
        PopupController.instance.popupHome.ShowImmediately(true, null);
    }
}
