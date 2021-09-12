using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;

public class AutoClickerManager : MonoBehaviour
{
    public static AutoClickerManager instance;
    private void Awake() => instance = this;
    public AutoClicker autoClicker;
    
    public BigDouble UpgradeBaseCost;
    public BigDouble UpgradeCostMult;
    
    public void StartUpgradeManager()
    {
        UpgradeBaseCost = 10;
        UpgradeCostMult = 1.33;
        UpdateUpgradeUI();
    }
    
    public void UpdateUpgradeUI()
    {
        var data = Controller.instance.data;
        autoClicker.LevelText.text = data.autoClickerUpgradeLevel.ToString();
        autoClicker.CostText.text = "Cost: " + Cost().ToString(format:"F0") + " Gamers";
    }
    
    public BigDouble Cost() => UpgradeBaseCost* BigDouble.Pow(UpgradeCostMult, Controller.instance.data.autoClickerUpgradeLevel);
    
    public void BuyUpgrade()
    {
        var data = Controller.instance.data;
        if (data.gamers >= Cost())
        {
            data.gamers -= Cost();
            data.autoClickerUpgradeLevel += 1;
        }

        UpdateUpgradeUI();
    }
}
