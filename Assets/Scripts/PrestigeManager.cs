using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;

public class PrestigeManager : MonoBehaviour
{
    public static PrestigeManager instance;
    private void Awake() => instance = this;
    public Prestige prestigeUpgrade;

    public string prestigeUpgradeName;
    public string prestigeUpgradeMultiplierText;

    public BigDouble prestigeUpgradeMultiplier;
    public BigDouble prestigeUpgradeBaseCost;
    public BigDouble prestigeUpgradeCostMult;
    public void StartPrestigeManager()
    {
        var data = Controller.instance.data;
        prestigeUpgradeName = "Gamers";
        prestigeUpgradeMultiplier = data.prestigeMultiplier * 1.5;
        prestigeUpgradeMultiplierText = prestigeUpgradeMultiplier + "x ";
        prestigeUpgradeBaseCost = 1000;
        prestigeUpgradeCostMult = 1.33;
        UpdatePrestigeUpgradeUI();
    }
    public void UpdatePrestigeUpgradeUI()
    {
        var data = Controller.instance.data;
        prestigeUpgrade.PrestigeLevelText.text = data.prestigeUpgradeLevel.ToString();
        prestigeUpgrade.CostText.text = "Cost: " + PrestigeCost().ToString(format: "F0") + " Gamers";
        prestigeUpgrade.PrestigeText.text = prestigeUpgradeMultiplierText + prestigeUpgradeName;
    }

    public BigDouble PrestigeCost() => prestigeUpgradeBaseCost * BigDouble.Pow(prestigeUpgradeCostMult, Controller.instance.data.prestigeUpgradeLevel);

    public void BuyPrestige()
    {
        var data = Controller.instance.data;
        if (data.gamers >= PrestigeCost())
        {
            data.gamers = 0;
            data.prestigeUpgradeLevel += 1;
            data.prestigeMultiplier = data.prestigeMultiplier * 1.5;
        }

        UpdatePrestigeUpgradeUI();
    }
}
