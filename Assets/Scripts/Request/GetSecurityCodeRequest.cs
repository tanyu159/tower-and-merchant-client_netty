using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSecurityCodeRequest :BaseRequest {

    public override void Awake()
    {
        requestType = RequestType.User;
        actionType = ActionType.GetSecurityCode;
        base.Awake();
    }

    void Start()
    {
    }
    /// <summary>
    /// 发送 获得邮箱验证码 请求
    /// </summary>
    /// <param name="email"></param>
    public void SendRequest(string email)
    {
        
        GetSecurityCodeRequestProto getSecurityCodeRequestProto = new GetSecurityCodeRequestProto(email);
        string jsonData= GetSecurityCodeRequestProto.packJsonData(getSecurityCodeRequestProto);
        Request getSecurityCodeRequest = new Request((int)requestType, (int)actionType, jsonData);
        byte[] dataBytes = ConverterTool.SerialRequestObj(getSecurityCodeRequest);
        GameFacade.Instance.ClientManager.SendMsgToServer(dataBytes);
    }

    /// <summary>
    /// 处理该获得邮箱验证码请求的响应
    /// </summary>
    /// <param name="data"></param>
    public override void OnResponse(string jsondata)
    {
        GetSecurityCodeResponseProto getSecurityCodeResponseProto = new GetSecurityCodeResponseProto(jsondata);
        ReturnType returnType = getSecurityCodeResponseProto.ReturnType;
        string msg = getSecurityCodeResponseProto.TipMsg;
        if (returnType == ReturnType.Successful)
        {
            Debug.Log("已成功发送验证码");
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg(msg);
        }
        else {
            Debug.Log("没有发送验证码");
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg(msg);
        }
    }
    
}
