using FishNet.Object;using UnityEngine;using System.Collections.Generic;
public class GuildHallSystem:NetworkBehaviour{
    public static GuildHallSystem Instance;
    void Awake(){Instance=this;}
    [ServerRpc]public void CmdCreateHall(EclipsePlayer p){if(p.guildRank!=0||p.guildGold<5000000)return;p.guildGold-=5000000;p.TargetShowMessage("Guild Hall kuruldu!");}
}