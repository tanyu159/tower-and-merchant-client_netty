using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 更新昵称请求，该脚本挂载到SetNickNamePanel上
/// </summary>
public class UpdateNickNameRequest : BaseRequest {
    private SetNickNamePanel _setNickNamePanel;
    public override void Awake()
    {
        requestType = RequestType.User;
        actionType = ActionType.UpdateNickName;
        base.Awake();
    }
    private void Start()
    {
        _setNickNamePanel = this.GetComponent<SetNickNamePanel>();
    }
    /// <summary>
    /// 发送更新昵称请求
    /// </summary>
    /// <param name="userid"></param>
    /// <param name="nickname"></param>
    public void SendRequest(int userid,string nickname)
    {
        string data = userid + "#" + nickname;
       // Request updateNickNameRequest = new Request((int)requestType,(int)actionType, data);
       // byte[] dataBytes = ConverterTool.SerialRequestObj(updateNickNameRequest);
       // GameFacade.Instance.ClientManager.SendMsgToServer(dataBytes);
    }

   /* public override void OnResponse(string data)
    {
        //解析结果
        ReturnType returnType = (ReturnType)int.Parse(data);
        if (returnType == ReturnType.Successful)
        {
            MessagePanel messagePanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            messagePanel.ShowTipsMsg("设置成功");
            //关闭按钮交互性和输入框交互性，避免重复
            _setNickNamePanel.enterButton.interactable = false;
            _setNickNamePanel.nickNameInputField.interactable = false;
        }
        else if(returnType==ReturnType.Failed) {
            MessagePanel messagePanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            messagePanel.ShowTipsMsg("设置失败");
        }
    }
    */
}
