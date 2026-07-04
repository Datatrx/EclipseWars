using FishNet.Object;using UnityEngine;using System.Collections.Generic;using UnityEngine.Purchasing;
public class IAPSystem:NetworkBehaviour,IStoreListener{
    public static IAPSystem Instance;
    IStoreController storeController;
    IAPConfig config;
    void Awake(){Instance=this;LoadConfig();}
    void LoadConfig(){
        TextAsset json=Resources.Load<TextAsset>("IAP_Config");
        config=JsonUtility.FromJson<IAPConfig>(json.text);
        InitializePurchasing();
    }
    void InitializePurchasing(){
        var builder=ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        foreach(var item in config.items)builder.AddProduct(item.id,item.type==0?ProductType.Consumable:ProductType.NonConsumable);
        UnityPurchasing.Initialize(this,builder);
    }
    public void OnInitialized(IStoreController c,IExtensionProvider e){storeController=c;}
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e){
        var item=config.items.Find(x=>x.id==e.purchasedProduct.definition.id);
        var p=EclipsePlayer.Local;
        if(item.rewardType=="gold")p.gold+=item.rewardAmount;
        else if(item.rewardType=="diamond")p.diamond+=item.rewardAmount;
        else if(item.rewardType=="mount")p.ownedMounts.Add(item.rewardId);
        else if(item.rewardType=="wing")p.ownedWings.Add(item.rewardId);
        return PurchaseProcessingResult.Complete;
    }
    public void OnPurchaseFailed(Product p,PurchaseFailureReason r){}
    public void OnInitializeFailed(InitializationFailureReason e){}
}
[System.Serializable]public class IAPConfig{public List<IAPItem> items;}
[System.Serializable]public class IAPItem{public string id,name,rewardType;public float price;public int type,rewardAmount,rewardId;}
