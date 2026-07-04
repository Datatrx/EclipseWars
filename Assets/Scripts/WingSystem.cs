using FishNet.Object;using UnityEngine;
public class WingSystem:NetworkBehaviour{
    public static WingSystem Instance;
    void Awake(){Instance=this;}
    [ServerRpc]public void CmdEquipWing(EclipsePlayer p,int id){if(!p.ownedWings.Contains(id))return;p.equippedWing=id;p.bonusAttack+=wingStats[id].attack;p.bonusHp+=wingStats[id].hp;p.RpcSetWingVisual(id,p.wingLevels[id]);}
    [ServerRpc]public void CmdUpgradeWing(EclipsePlayer p){if(p.equippedWing<0)return;int cost=100000*(p.wingLevels[p.equippedWing]+1);if(p.gold<cost)return;p.gold-=cost;p.wingLevels[p.equippedWing]++;p.bonusAttack+=50;p.bonusHp+=200;p.RpcWingUpgradeEffect(p.equippedWing,p.wingLevels[p.equippedWing]);}
    public static WingData[] wingStats=new WingData[]{
        new WingData{attack=50,hp=200},new WingData{attack=100,hp=400},new WingData{attack=150,hp=600},new WingData{attack=200,hp=800},new WingData{attack=250,hp=1000},
        new WingData{attack=300,hp=1500},new WingData{attack=400,hp=1000},new WingData{attack=300,hp=1200},new WingData{attack=200,hp=2500},new WingData{attack=500,hp=2000}
    };
}
public class WingData{public int attack,hp;}
