using FishNet.Object;using UnityEngine;using System.Collections;using System.Collections.Generic;
public class DungeonSystem:NetworkBehaviour{
    public static DungeonSystem Instance;
    void Awake(){Instance=this;}
    [ServerRpc]public void CmdEnterDungeon(EclipsePlayer p,int dungeonId,int difficulty){
        if(p.dungeonTicket<1){p.TargetShowMessage("Bilet yok!");return;}
        p.dungeonTicket--;
        p.RpcTeleportToDungeon("Dungeon_"+dungeonId);
        p.TargetShowMessage("Dungeon başladı!");
    }
}