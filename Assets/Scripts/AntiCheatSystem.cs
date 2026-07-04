using FishNet.Object;using UnityEngine;using System.Collections.Generic;
public class AntiCheatSystem:NetworkBehaviour{
    public static AntiCheatSystem Instance;
    public float maxSpeed=10f,maxGoldGain=100000f;
    Dictionary<EclipsePlayer,PlayerStats> stats=new();
    void Awake(){Instance=this;}
    void Update(){if(IsServer)CheckPlayers();}
    void CheckPlayers(){
        foreach(var p in FindObjectsOfType<EclipsePlayer>()){
            if(!stats.ContainsKey(p))stats[p]=new PlayerStats();
            var s=stats[p];
            float dist=Vector3.Distance(p.transform.position,s.lastPos);
            if(dist>maxSpeed*Time.deltaTime*2f){s.violations++;if(s.violations>3)p.connection.Disconnect();}
            if(p.gold-s.lastGold>maxGoldGain)p.connection.Disconnect();
            s.lastPos=p.transform.position;s.lastGold=p.gold;
        }
    }
    class PlayerStats{public Vector3 lastPos;public int lastGold,violations;}
}