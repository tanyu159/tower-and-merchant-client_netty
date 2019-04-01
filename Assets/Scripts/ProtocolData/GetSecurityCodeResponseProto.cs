

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSecurityCodeResponseProto  {

    private ReturnType returnType;
    private string tipMsg;

    public ReturnType ReturnType
    {
        get
        {
            return returnType;
        }

        
    }

    public string TipMsg
    {
        get
        {
            return tipMsg;
        }

        
    }
    /// <summary>
    /// 将json数据还原为该响应的协议对象
    /// </summary>
    /// <param name="jsonData"></param>
    public GetSecurityCodeResponseProto(string jsonData)
    {
        //todo 解析json，设置GetSecurityCodeResponseProto类对象
        JObject jo = (JObject)JsonConvert.DeserializeObject(jsonData);
        returnType = (ReturnType)int.Parse(jo["returnType"].ToString());
        tipMsg = jo["tipMsg"].ToString();
    }

   
}
