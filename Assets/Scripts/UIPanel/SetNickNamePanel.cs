using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 设置昵称面板，首次登录时会打开
/// </summary>
public class SetNickNamePanel : BasePanel {
    private int userid;
    public InputField nickNameInputField;
    public Button enterButton;
    public Button closeButton;
    private UpdateNickNameRequest _updateNickNameRequest; 
    public void SetUserid(int userid)
    {
        this.userid = userid;
    }
    private void Start()
    {
        _updateNickNameRequest = this.GetComponent<UpdateNickNameRequest>();
        enterButton.onClick.AddListener(delegate() { EnterButtonClicked(); });
    }

    private void CloseButtonClicked()
    {
        GameFacade.Instance.UiManager.PopPanel();
    }

    private void EnterButtonClicked()
    {
        if (nickNameInputField.text != null && nickNameInputField.text != "")
        {
            //todo发送更新nickname请求
            _updateNickNameRequest.SendRequest(userid, nickNameInputField.text);
        }
        else {
            MessagePanel messagePanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            messagePanel.ShowTipsMsg("昵称格式不对");
        }
    }

    //重写的函数

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
    public override void OnExit()
    {
        this.gameObject.SetActive(false);
    }
}
