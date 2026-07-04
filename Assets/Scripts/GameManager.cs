using FishNet.Object;using UnityEngine;
public class GameManager:NetworkBehaviour{
    public static GameManager Instance;
    void Awake(){Instance=this;}
}