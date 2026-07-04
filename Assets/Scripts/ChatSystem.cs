using FishNet.Object;using UnityEngine;using System;
public class ChatSystem:NetworkBehaviour{
    public static ChatSystem Instance;
    void Awake(){Instance=this;}
    [ServerRpc(RequireOwnership=false)]public void CmdSendMessage(EclipsePlayer sender,string msg,int channel,string lang){
        if(Time.time-sender.lastChatTime<1.5f)return;
        sender.lastChatTime=Time.time;
        ChatMessage data=new ChatMessage{senderName=sender.playerName,message=msg,channel=channel,senderLang=lang,timestamp=DateTime.Now};
        RpcReceiveMessage(data);
    }
    [ObserversRpc]void RpcReceiveMessage(ChatMessage msg){}
}
[System.Serializable]public class ChatMessage{public string senderName,message,senderLang;public int channel;public DateTime timestamp;}
