using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSave  {
    private int _id;
    private int _userid;
    private string _nickname;
    private byte _baselevel;
    private int _coin;
    private int _diamond;
    public UserSave(int id,int userid,string nickname,byte baselevel,int coin,int diamond)
    {
        _id = id;
        _userid = userid;
        _nickname = nickname;
        _baselevel = baselevel;
        _coin = coin;
        _diamond = diamond;
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

    public UserSave()
    { }

    public int Userid
    {
        get
        {
            return _userid;
        }

        set
        {
            _userid = value;
        }
    }

    public string Nickname
    {
        get
        {
            return _nickname;
        }

        set
        {
            _nickname = value;
        }
    }

    public byte Baselevel
    {
        get
        {
            return _baselevel;
        }

        set
        {
            _baselevel = value;
        }
    }

    public int Coin
    {
        get
        {
            return _coin;
        }

        set
        {
            _coin = value;
        }
    }

    public int Diamond
    {
        get
        {
            return _diamond;
        }

        set
        {
            _diamond = value;
        }
    }

    
}
