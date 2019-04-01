using ProtoBuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// 该类为工具类，用于在通讯时int与byte[]数组互相转换
/// </summary>
public class ConverterTool  {
    /// <summary>
    /// int类型转byte数组
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static byte[] IntToBytes(int num)
    {
        byte[] bytes = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            bytes[i] = (byte)(num >> (24 - i * 8));
        }
        return bytes;
    }
    /// <summary>
    /// byte数组转
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="statIdx"></param>
    /// <returns></returns>
    public static int BytesToInt(byte[] bytes, int startIdx)
    {
        int num = 0;
        for (int i = startIdx; i < startIdx + 4; i++)
        {
            num <<= 8;
            num |= (bytes[i] & 0xff);
        }
        return num;
    }
    /// <summary>
    /// 将Request对象进行编码为二进制流，返回byte数组
    /// </summary>
    /// <param name="requestObj"></param>
    /// <returns></returns>
    public static byte[] SerialRequestObj(Request requestObj)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Serializer.Serialize<Request>(ms, requestObj);
            byte[] data = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(data, 0, data.Length);
            return data;
        }
    }
    /// <summary>
    /// 将二进制流反编码为Response对象
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static Response DeSerialToResponseObj(byte[] bytes)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;
            Response responseObj = Serializer.Deserialize<Response>(ms);
            return responseObj; 

        }
    }
	
}
