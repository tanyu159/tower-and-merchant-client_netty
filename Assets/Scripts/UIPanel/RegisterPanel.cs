using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel {

    public Button closeBtn;
    public Button getSecurityCodeBtn;
    public Button executeRegisterBtn;
    public InputField email_InputField;
    public InputField emailSecurityCode_InputField;
    public InputField password_InputField;
    public InputField repeatePassword_InputField;
    public InputField idCard_InputField;
    //Request组件
    private GetSecurityCodeRequest _getSecurityCodeRequest;
    private RegisterRequest _registerRequest;
    private void Start()
    {
        //注册按钮点击事件
        closeBtn.onClick.AddListener(delegate () { CloseButtonClicked(); });
        getSecurityCodeBtn.onClick.AddListener(delegate () { GetSecurityCodeButtonClicked(); });
        executeRegisterBtn.onClick.AddListener(delegate () { ExecuteRegisterButtonClicked(); });
        //初始化Request组件
        _getSecurityCodeRequest = this.GetComponent<GetSecurityCodeRequest>();
        _registerRequest = this.GetComponent<RegisterRequest>();
    }

    private void CloseButtonClicked()
    {
        GameFacade.Instance.UiManager.PopPanel();
    }
    /// <summary>
    /// 获得验证码按钮点击事件
    /// </summary>
    private void GetSecurityCodeButtonClicked()
    {
        string emailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        if (Regex.IsMatch(email_InputField.text,emailRegex))
        {
            _getSecurityCodeRequest.SendRequest(email_InputField.text);
        }
        else {
            MessagePanel msgPanel= GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg("邮箱格式不正确");
        }
    }

    private void ExecuteRegisterButtonClicked()
    {
        //前端校验
        bool isOk = FormatVerifty();
        if (isOk)
        {
            //.执行注册请求
            _registerRequest.SendRequest(emailSecurityCode_InputField.text, email_InputField.text, password_InputField.text, idCard_InputField.text);
        }
    }
    /// <summary>
    /// 前端校验，来确定格式对不对
    /// </summary>
    /// <returns></returns>
    private bool FormatVerifty()
    {
        if (password_InputField.text == "" || password_InputField == null)
        {
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg("密码不能为空");
            return false;
        }
        if (!password_InputField.text.Equals(repeatePassword_InputField.text))
        {
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg("两次密码不同");
            return false;
        }
        if (password_InputField.text.Contains("#"))
        {
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg("密码中不能包含特殊字符");
            return false;
        }
        if (idCard_InputField.text == null || idCard_InputField.text == "" || idCard_InputField.text.Length < 18)
        {
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg("身份证格式不对");
            return false;
        }
        return true;
    }
    #region 重写的函数
    public override void OnEnter()
    {
        if (this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
        }
    }
    public override void OnExit()
    {
        this.gameObject.SetActive(false);
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
