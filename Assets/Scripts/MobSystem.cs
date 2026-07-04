using FishNet.Object;using UnityEngine;using System.Collections.Generic;
public class MobSystem:NetworkBehaviour{
    public static MobSystem Instance;
    public List<MobData> mobData=new();
    void Awake(){Instance=this;LoadMobData();}
    void LoadMobData(){TextAsset json=Resources.Load<TextAsset>("MobData");MobConfig cfg=JsonUtility.FromJson<MobConfig>(json.text);mobData=cfg.mobs;}
    public int GetExpForLevel(int level){return level*1000+(level*level*100);}
}
[System.Serializable]public class MobConfig{public List<MobData> mobs;}
[System.Serializable]public class MobData{public int id,level,hp,exp,gold;public string name;}
