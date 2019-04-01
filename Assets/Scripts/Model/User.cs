using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 数据模型 User，与服务器的User相同
/// </summary>
public class User {

    private int _id;
    private string _email;
    private string _password;
    private string _idcard;
    public User() { }
    public User(int id, string email, string password,string idcard)
    {
        _id = id;
        _email = email;
        _password = password;
        _idcard = idcard;
    }
    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    public string Email
    {
        get
        {
            return _email;
        }

        set
        {
            _email = value;
        }
    }

    public string Password
    {
        get
        {
            return _password;
        }

        set
        {
            _password = value;
        }
    }
}

