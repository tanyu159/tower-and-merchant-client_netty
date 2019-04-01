using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSecurityCodeRequestProto  {
    private string email;
    public string Email { get { return email; } }
    public GetSecurityCodeRequestProto(string email)
    {
        this.email = email;
    }
    /// <summary>
    /// 将该请求协议对象封装为json数据【序列化为】
    /// </summary>
    /// <param name="requestProto"></param>
    /// <returns></returns>
    public static string packJsonData(GetSecurityCodeRequestProto requestProto)
    {
        //
        string email = requestProto.Email;
        string jsonData = "{\"email\":\"" + email + "\"}";
        return jsonData;
    }

}
