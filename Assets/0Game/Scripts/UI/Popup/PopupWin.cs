using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWin : BasePopup
{
    [SerializeField] private Button btnReset, btnHome, btnNext;
    [SerializeField] private List<StarCtrl> starLs = new List<StarCtrl>();
    private void Awake()
    {
        btnReset.onClick.AddListener(ResetLevel);
        btnHome.onClick.AddListener(ShowHome);
        btnNext.onClick.AddListener(NextLevel);
    }

    private void ResetLevel()
    {
        HideImmediately(false);
        GameController.instance.ResetLevel();
    }

    private void ShowHome()
    {
        HideImmediately(false);
        PopupController.instance.popupLevel.ShowImmediately(false, null);
    }

    private void NextLevel()
    {
        HideImmediately(false);
        GameController.instance.NextLevel();
    }
    public void ShowStar(int amount)
    {
        StartCoroutine(Show(amount));
    }

    IEnumerator Show(int amount)
    {
        int i = 0;
        yield return new WaitForSeconds(0.5f);
        while (i < amount)
        {
            starLs[i].GrowUpStar();
            yield return new WaitForSeconds(0.8f);
            i++;
        }
    }
}
