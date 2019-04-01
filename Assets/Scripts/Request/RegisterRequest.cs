using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterRequest : BaseRequest {
    private RegisterPanel _registerPanel;
    public override void Awake()
    {
        requestType = RequestType.User;
        actionType = ActionType.Register;
        base.Awake();
    }

    private void Start()
    {
        _registerPanel = this.GetComponent<RegisterPanel>();
    }
    /// <summary>
    /// 发送注册请求
    /// </summary>
    /// <param name="securityCode"></param>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <param name="idcard"></param>
    public void SendRequest(string securityCode,string email,string password,string idcard)
    {
        string data = securityCode + "#" + email + "#" + password + "#" + idcard;
        //Request registerRequest = new Request((int)requestType, (int)actionType, data);
        //byte[] dataBytes = ConverterTool.SerialRequestObj(registerRequest);
        //GameFacade.Instance.ClientManager.SendMsgToServer(dataBytes);
    }
    /// <summary>
    /// 处理注册请求的响应
    /// </summary>
    /// <param name="data"></param>
   /* public override void OnResponse(string data)
    {
        string[] dataStrArr = data.Split('#');
        ReturnType returnType = (ReturnType)int.Parse(dataStrArr[0]);
        string msg = dataStrArr[1];
        if (returnType == ReturnType.Successful)
        {
            //说明注册成功
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg(msg);
            //关闭按钮交互性，防止再次注册
            _registerPanel.getSecurityCodeBtn.interactable = false;
            _registerPanel.executeRegisterBtn.interactable = false;
        }
        else {
            //说明注册失败：原因只可能是验证码输错了
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg(msg);
        }
    }
    */
}
