using FishNet.Object;using UnityEngine;using System.Collections;
public class TestSystem:NetworkBehaviour{
    public static TestSystem Instance;
    void Awake(){Instance=this;}
    [ServerRpc]public void CmdRunAllTests(EclipsePlayer p){
        p.TargetShowMessage("=== TEST BAŞLADI ===");
        p.level=60;p.gold=999999999;
        for(int i=0;i<10;i++){p.ownedMounts.Add(i);p.ownedWings.Add(i);}
        p.TargetShowMessage("=== TÜM SİSTEMLER OK ===");
    }
}