using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCtrl : MonoBehaviour
{
    [SerializeField] private Animator anm;

    public void ShowStar(bool _en)
    {
        if (_en)
        {
            anm.CrossFade("StarWin", 0);
        }
        else
        {
            anm.CrossFade("StarLose", 0);
        }
    }

    public void GrowUpStar()
    {
        anm.CrossFade("StarUp", 0);
    }
}
