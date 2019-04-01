
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRequest : MonoBehaviour {

    //用来区分Controller
    protected RequestType requestType=RequestType.None;
    //Controller相同时区分具体执行的函数
    protected ActionType actionType = ActionType.None;

    //调试用
    public RequestType RequestType { get { return requestType; } }
    public ActionType ActionType { get { return actionType; } }
    public virtual	void Awake () {
        //初始化RequestCode类型	
        //加入到字典
        GameFacade.Instance.RequestManager.AddRequestToDictionary(actionType, this);
	}

    /// <summary>
    /// 发送请求
    /// </summary>
    public virtual void SendRequest()
    {

    }

    /// <summary>
    /// 执行收该请求的响应
    /// </summary>
    public virtual void OnResponse(string jsonData)
    {

    }

    public virtual void OnDestroy()
    {
        GameFacade.Instance.RequestManager.RemoveRequestFromDictionary(actionType);
    }
}
