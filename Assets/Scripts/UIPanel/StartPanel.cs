using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartPanel : BasePanel {
    public Button loginBtn;
    public Button registerBtn;

    private void Start()
    {
        loginBtn.onClick.AddListener(delegate () { LoginButtonClicked(); });
        registerBtn.onClick.AddListener(delegate () { RegisterButtonClicked(); });
    }
    //按钮点击函数
    private void LoginButtonClicked()
    {
        GameFacade.Instance.UiManager.PushPanel(PanelType.Login);
    }

    private void RegisterButtonClicked()
    {
        GameFacade.Instance.UiManager.PushPanel(PanelType.Register);
    }
    #region 重写的函数
    public override void OnEnter()
    {
        if (this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
        }
    }

    public override void OnPause()
    {
        this.gameObject.SetActive(false);
    }
    public override void OnResume()
    {
        this.gameObject.SetActive(true);
    }
    #endregion
}
