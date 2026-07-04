using UnityEngine;
public class UIManager:MonoBehaviour{
    public static UIManager Instance;
    void Awake(){Instance=this;}
    public void ShowPopup(string msg){Debug.Log(msg);}
}