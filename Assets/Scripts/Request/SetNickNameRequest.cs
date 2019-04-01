using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 该请求只有接受响应，没有发送请求方法，挂在到LoginPanel上
/// </summary>
public class SetNickNameRequest : BaseRequest {

    public override void Awake()
    {
        requestType = RequestType.User;
        actionType = ActionType.SetNickName;
        base.Awake();
    }

    private void Start()
    {
        
    }

    /*public override void OnResponse(string data)
    {
        //获得设置的玩家的id
        int userid = int.Parse(data);
        //开启设置昵称面板
        SetNickNamePanel setNickNamePanel= GameFacade.Instance.UiManager.PushPanel(PanelType.SetNickName) as SetNickNamePanel;
        setNickNamePanel.SetUserid(userid);

    }
    */
}
