using FishNet.Object;using UnityEngine;using System.Collections.Generic;
public class EclipsePlayer:NetworkBehaviour{
    [SyncVar] public string playerName,playerId;
    [SyncVar] public int level=1,exp,vipLevel=0,classType;
    [SyncVar] public int gold,diamond;
    [SyncVar] public int equippedMount=-1,equippedWing=-1,equippedCostume=-1;
    [SyncVar] public bool isMounted=false;
    [SyncVar] public float moveSpeed=5f,bonusSpeed=0f,bonusAttack=0f,bonusHp=0f,lastAttackTime;
    [SyncVar] public int guildId=-1,guildRank=2;
    [SyncVar] public long guildGold;
    [SyncVar] public int dungeonTicket=3,raidDamage=0;
    [SyncVar] public float lastChatTime,lastDamage,maxDamage=100;
    
    public List<int> ownedMounts=new(),ownedWings=new(),ownedCostumes=new(),ownedHairs=new(),ownedPets=new();
    public int[] mountLevels=new int[10],wingLevels=new int[10],costumeColors=new int[5];
    public Dictionary<int,int> inventory=new();
    
    public static EclipsePlayer Local;
    public override void OnStartClient(){if(IsOwner)Local=this;}
    
    public bool HasItem(int id)=>inventory.ContainsKey(id);
    public bool HasItemCount(int id,int count)=>inventory.ContainsKey(id)&&inventory[id]>=count;
    public void AddItem(int id,int count=1){if(inventory.ContainsKey(id))inventory[id]+=count;else inventory[id]=count;}
    public void RemoveItem(int id){if(inventory.ContainsKey(id))inventory[id]--;if(inventory[id]<=0)inventory.Remove(id);}
    public void RemoveItemCount(int id,int count){if(inventory.ContainsKey(id)){inventory[id]-=count;if(inventory[id]<=0)inventory.Remove(id);}}
    
    [TargetRpc] public void TargetShowMessage(string msg){UIManager.Instance?.ShowPopup(msg);}
    [ObserversRpc] public void RpcSetMountVisual(int id,int lvl){}
    [ObserversRpc] public void RpcSetWingVisual(int id,int lvl){}
    [ObserversRpc] public void RpcSetCostumeVisual(int id,int color){}
    [ObserversRpc] public void RpcTeleportToHall(GuildHall hall){}
    [ObserversRpc] public void RpcTeleportToDungeon(string scene){}
    [ObserversRpc] public void RpcTeleportToRaid(string scene){}
    [ObserversRpc] public void RpcTeleportToTown(){}
    [ObserversRpc] public void RpcMountUpgradeEffect(){}
    [ObserversRpc] public void RpcWingUpgradeEffect(int id,int lvl){}
}