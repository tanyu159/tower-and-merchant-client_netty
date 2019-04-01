
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginRequest : BaseRequest {
    private LoginPanel _loginPanel;

    public override void Awake()
    {
        //【注意】保证先设置正确RequestCode和ActionCode，再添加到列表中
        //设置枚举类型
        requestType = RequestType.User;
        actionType = ActionType.Login;
        base.Awake();
    }
    private void Start()
    {
        //初始化
        _loginPanel = this.GetComponent<LoginPanel>();
      
    }
    /// <summary>
    /// 发送登录请求
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    public void SendRequest(string username, string password)
    {
        //包装数据【非封包】
        string data = username + "#" + password;//用#做分割,服务器按#分割即可
        //封装为Request对象
        //Request loginRequest = new Request((int)requestType,(int)actionType,data);
        //发送请求.【但只能发送二进制流】
        //先转换为二进制流
        //byte[] loginRequestBytes = ConverterTool.SerialRequestObj(loginRequest);
      //  GameFacade.Instance.ClientManager.SendMsgToServer(loginRequestBytes);
    }

    /// <summary>
    /// 处理登录请求的来自服务器端的响应
    /// </summary>
    /// <param name="data"></param>
   /* public override void OnResponse(string data)
    {
        string[] dataStrArr = data.Split('*');
        ReturnType returnType = (ReturnType)int.Parse(dataStrArr[0]);
        string dataContent = dataStrArr[1];
        if (returnType == ReturnType.Failed)
        {
            //显示来自服务器的错误信息
            MessagePanel msgPanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg(dataContent);
        }
        else if (returnType == ReturnType.Successful)
        {
            //解析玩家数据
            string[] playerDataStrArr = dataContent.Split('#');
            string nickname = playerDataStrArr[0];
            byte baselevel = byte.Parse(playerDataStrArr[1]);
            int coin = int.Parse(playerDataStrArr[2]);
            int diamond = int.Parse(playerDataStrArr[3]);
            //构造UserSave对象
            UserSave userSave = new UserSave();
            userSave.Nickname = nickname;
            userSave.Baselevel = baselevel;
            userSave.Coin = coin;
            userSave.Diamond = diamond;
            //设置PlayerManager
            GameFacade.Instance.PlayerManager.currentLoginedUserSave = userSave;
            //打开游戏主界面Panel_Game，并设置游戏数据显示
            GamePanel gamePanel = GameFacade.Instance.UiManager.PushPanel(PanelType.Game) as GamePanel;
            gamePanel.SetPlayerInfo(userSave.Nickname,userSave.Baselevel,userSave.Coin,userSave.Diamond);

            
            
         
        }
       


    }
     */
}
