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

    public BigDouble prestigeUpgradeMultiplier;
    public BigDouble prestigeUpgradeBaseCost;
    public BigDouble prestigeUpgradeCostMult;
    public void StartPrestigeManager()
    {
        var data = Controller.instance.data;
        prestigeUpgradeName = "Gamers";
        prestigeUpgradeBaseCost = 100000;
        prestigeUpgradeCostMult = 1.75;
        UpdatePrestigeUpgradeUI();
    }
    public void UpdatePrestigeUpgradeUI()
    {
        var data = Controller.instance.data;
        prestigeUpgradeMultiplier = data.prestigeMultiplier * 2;
        prestigeUpgrade.PrestigeLevelText.text = data.prestigeUpgradeLevel.ToString();
        prestigeUpgrade.CostText.text = "Cost: " + PrestigeCost().ToString(format: "F0") + " Gamers";
        prestigeUpgrade.PrestigeText.text = prestigeUpgradeMultiplier.ToString(format: "F0") + "x " + prestigeUpgradeName;
    }

    public BigDouble PrestigeCost() => prestigeUpgradeBaseCost * BigDouble.Pow(prestigeUpgradeCostMult, Controller.instance.data.prestigeUpgradeLevel);

    public void BuyPrestige()
    {
        var data = Controller.instance.data;
        if (data.gamers >= PrestigeCost())
        {
            data.gamers = 0;
            data.clickUpgradeLevel = 0;
            data.prestigeUpgradeLevel += 1;
            data.prestigeMultiplier = data.prestigeMultiplier * 2;
        }

        UpdatePrestigeUpgradeUI();
        ClickUpgradesManager.instance.UpdateClickUpgradeUI();
    }
}
