using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static ShopController instance;
    private void Awake() => instance = this;

    [SerializeField] private TMP_Text gamersText;

    public const string dataFileName = "PlayerData_Gamer";
    
    public void ShopInit()
    {
        var data = Controller.instance.data;
        data = SaveSystem.SaveExists(dataFileName)
            ? SaveSystem.LoadData<Data>(dataFileName)
            : new Data();
        
        AutoClickerManager.instance.StartUpgradeManager();
    }
    
    public void LoadGamers()
    {
        
    }
}
