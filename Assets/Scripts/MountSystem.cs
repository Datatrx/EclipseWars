using FishNet.Object;using UnityEngine;
public class MountSystem:NetworkBehaviour{
    public static MountSystem Instance;
    void Awake(){Instance=this;}
    [ServerRpc]public void CmdEquipMount(EclipsePlayer p,int id){if(!p.ownedMounts.Contains(id))return;p.equippedMount=id;p.isMounted=true;p.moveSpeed=mountStats[id].speed; p.RpcSetMountVisual(id,p.mountLevels[id]);}
    [ServerRpc]public void CmdUpgradeMount(EclipsePlayer p){if(p.equippedMount<0)return;int cost=100000*(p.mountLevels[p.equippedMount]+1);if(p.gold<cost)return;p.gold-=cost;p.mountLevels[p.equippedMount]++;p.moveSpeed*=1.1f;p.RpcMountUpgradeEffect();}
    public static MountData[] mountStats=new MountData[]{
        new MountData{speed=1.5f},new MountData{speed=1.6f},new MountData{speed=1.7f},new MountData{speed=1.8f},new MountData{speed=2.0f},
        new MountData{speed=2.2f},new MountData{speed=2.2f},new MountData{speed=2.5f},new MountData{speed=2.5f},new MountData{speed=3.0f}
    };
}
public class MountData{public float speed;}
