
using ProtoBuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
/// <summary>
/// 管理服务器的Socket连接
/// </summary>
public class ClientManager :BaseManager {
    /// <summary>
    /// IP地址
    /// </summary>
    private const string IP = "127.0.0.1";
    /// <summary>
    /// 端口号
    /// </summary>
    private const int port = 7878;
    private TcpClient client;
    private int len;
    private bool isHead;
    private bool isConnected = false;

    public ClientManager(GameFacade gameFacade) : base(gameFacade)
    {

    }

    public override void Update()
    {
        //时刻接收来自服务器的信息-不用新开线程了，都在主线程中，后面的Response函数也不用通过修改标志位的方式进行操作
        //Unity主线程的东西了【！！！】
        if (isConnected)
        {
            ReceiveMsgFromClient();
        }
    }


    /// <summary>
    /// 重写onInit进行服务器的连接
    /// </summary>
    public override void OnInit()
    {
        try
        {
            client = new TcpClient();
            client.Connect(IP,port);
            isHead = true;
            isConnected = true;

        }
        catch (Exception e)
        {
            Debug.LogError("无法连接服务器，异常信息为" + e);
            //打开MessagePanel显示信息给用户
            MessagePanel msgPanel= GameFacade.Instance.UiManager.PushPanel(PanelType.Message) as MessagePanel;
            msgPanel.ShowTipsMsg("未能和服务器连接");
        }
    }

    /// <summary>
    /// 发送消息到服务器
    /// </summary>
    /// <param name="msg"></param>
    public void SendMsgToServer(byte[] msg)
    {
        //消息体结构：消息体长度+消息体
        byte[] data = new byte[4 + msg.Length];
        ConverterTool.IntToBytes(msg.Length).CopyTo(data, 0);
        msg.CopyTo(data, 4);
        client.GetStream().Write(data, 0, data.Length);
    }
    /// <summary>
    /// 接收来自服务器的消息
    /// </summary>
    public void ReceiveMsgFromClient()
    {
        NetworkStream stream = client.GetStream();
        if (!stream.CanRead)
        {
            return;
        }
        //读取消息体的长度
        if (isHead)
        {
            if (client.Available < 4)
            {
                return;
            }
            byte[] lenByte = new byte[4];
            stream.Read(lenByte, 0, 4);
            len = ConverterTool.BytesToInt(lenByte, 0);
            isHead = false;
        }
        //读取消息体内容
        if (!isHead)
        {
            if (client.Available < len)
            {
                return;
            }
            byte[] msgByte = new byte[len];
            stream.Read(msgByte, 0, len);
            isHead = true;
            len = 0;
            //生成Response对象，根据这个对象再看具体的执行
            //解析得到具体消息对象 reponseObj，然后执行具体的操作,利用反射机制
            Response responseObj= ConverterTool.DeSerialToResponseObj(msgByte);
            GameFacade.Instance.RequestManager.HandleRespone((ActionType)responseObj.actionType, responseObj.jsonData);
        }
    }

    

    public override void OnDestroy()
    {
        base.OnDestroy();
        try
        {
            if (client != null)
            {
                client.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogError("无法关闭与服务器的连接，异常信息:" + e);
        }
    }
}
