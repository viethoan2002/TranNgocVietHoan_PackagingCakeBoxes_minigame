using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static PopupController instance;

    public PopupHome popupHome;
    public PopupGuid popupGuid;
    public PopupLevel popupLevel;
    public PopupWin popupWin;
    public PopupLose popupLose;
    public PopupGameplay popupGameplay;

    private void Awake()
    {
        instance = this;
    }
}
