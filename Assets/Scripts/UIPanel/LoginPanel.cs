using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Text.RegularExpressions;

public enum ActionState { StandBy,Failed,Success}
public class LoginPanel : BasePanel {

   
    public Button closeBtn;//关闭面板按钮
    public Button executeLoginBtn;//执行登录
    public InputField usernameInputField;//用户名输入框【邮箱】
    public InputField passwordInputField;//密码输入框
    private LoginRequest _loginRequestObj;//登录请求对象

    
    private void Start()
    {
        //初始化登录请求对象
        _loginRequestObj = this.GetComponent<LoginRequest>();
        //绑定监听点击事件
        closeBtn.onClick.AddListener(delegate() { CloseButtonClicked(); });
        executeLoginBtn.onClick.AddListener(delegate() { ExecuteLoginButtonClicked(); });
       
    }

    private void Update()
    {
       
    }
    /// <summary>
    /// 处理登录的响应-并接收战绩数据
    /// </summary>
    /// <param name="isSuccessful">是否登录成功</param>
    /// <param name="data">登录成功情况下的战绩数据</param>
    public void HandleLoginResponse(bool isSuccessful)
    {
        
    }

    #region 按钮点击事件
    private void CloseButtonClicked()
    {
        
        //该面板出栈-会执行该面板的OnExit方法，需重写OnExit
        GameFacade.Instance.UiManager.PopPanel();
    }

    private void ExecuteLoginButtonClicked()
    {
      

        //:执行登录操作
        Debug.Log("输入的用户名" + usernameInputField.text);
        Debug.Log("输入的密码" + passwordInputField.text);
        //前端校验-这里只用进行判断为空的校验，在注册的时候才进行格式，长度等校验
        string emailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        if (Regex.IsMatch(usernameInputField.text, emailRegex))
        {
            if (passwordInputField.text != null && passwordInputField.text != "")
            {
                //通过loginRequest对象发送请求
                _loginRequestObj.SendRequest(usernameInputField.text, passwordInputField.text);
            }
            else {
                MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
                msgPanel.ShowTipsMsg("密码不能为空");
            }
        }
        else {
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg("邮箱格式不正确");
        }
        

    }
    
  
    #endregion

  


    #region 重写的方法 UI相关的逻辑
    public override void OnEnter()
    {
        //此为保证已经开过一次了，但又关闭过【执行OnExit被取消激活了】，再次开启时保证要激活状态
        if (this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
        }
       
    }

    //注册面板开启时要暂停
    public override void OnPause()
    {
       
        this.gameObject.SetActive(false);
    }

    //注册面板关闭时要恢复
    public override void OnResume()
    {
       
        //恢复激活
        this.gameObject.SetActive(true);

    }
    //PopPanel要调用
    public override void OnExit()
    {

        this.gameObject.SetActive(false);
    }
    #endregion
}
