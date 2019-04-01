
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
[ProtoContract]
public class Response  {
    [ProtoMember(1)]
    public int actionType;
    [ProtoMember(2)]
    public string jsonData;

}
