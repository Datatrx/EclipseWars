using FishNet.Object;using UnityEngine;using System.Collections.Generic;
public class RaidSystem:NetworkBehaviour{
    public static RaidSystem Instance;
    void Awake(){Instance=this;}
    [ServerRpc]public void CmdStartRaid(EclipsePlayer p,int raidId){if(p.guildRank!=0)return;p.TargetShowMessage("Raid başladı!");}
    [ServerRpc]public void CmdJoinRaid(EclipsePlayer p){p.RpcTeleportToRaid("Raid_0");}
}