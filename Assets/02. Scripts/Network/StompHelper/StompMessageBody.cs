using System;
using System.Collections.Generic;

[System.Serializable]
public class StompMessageBody
{
    public string data;
    public string type;
    public string channelId;
    public string sender;
}


