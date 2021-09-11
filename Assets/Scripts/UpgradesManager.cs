using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager instance;
    private void Awake() => instance = this;
    public Upgrades clickUpgrade;

    public string clickUpgradeName;

    public BigDouble clickUpgradeBaseCost;
    public BigDouble clickUpgradeCostMult;

    public void StartUpgradeManager()
    {
        clickUpgradeName = "Gamers Per Click";
        //clickUpgradeAmount = "+" + 
        clickUpgradeBaseCost = 10;
        clickUpgradeCostMult = 1.33;
        UpdateClickUpgradeUI();
    }

    public void UpdateClickUpgradeUI()
    {
        var data = Controller.instance.data;
        clickUpgrade.LevelText.text = data.clickUpgradeLevel.ToString();
        clickUpgrade.CostText.text = "Cost: " + Cost().ToString(format:"F0") + " Gamers";
        clickUpgrade.NameText.text = "+1 " + clickUpgradeName;
    }

    public BigDouble Cost() => clickUpgradeBaseCost* BigDouble.Pow(clickUpgradeCostMult, Controller.instance.data.clickUpgradeLevel);

    public void BuyUpgrade()
    {
        var data = Controller.instance.data;
        if (data.gamers >= Cost())
        {
            data.gamers -= Cost();
            data.clickUpgradeLevel += 1;
        }

        UpdateClickUpgradeUI();
    }
}
