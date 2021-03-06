using System;
using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;

[Serializable]
public class Data
{
    public BigDouble gamers;

    public BigDouble clickUpgradeLevel;

    public BigDouble autoClickerUpgradeLevel;

    public BigDouble prestigeUpgradeLevel;

    public BigDouble prestigeMultiplier;

    public Data()
    {
        gamers = 0;

        clickUpgradeLevel = 0;

        autoClickerUpgradeLevel = 0;

        prestigeUpgradeLevel = 0;

        prestigeMultiplier = 1;
    }
}
