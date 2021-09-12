using UnityEngine;
using TMPro;
using BreakInfinity;
using JetBrains.Annotations;


public class Controller : MonoBehaviour
{
    public static Controller instance;
    private void Awake() => instance = this;

    public Data data;

    [SerializeField] private TMP_Text gamersText;
    [SerializeField] private TMP_Text gamerClickPowerText;
    public BigDouble ClickPower() => data.prestigeMultiplier * (1 + data.clickUpgradeLevel);

    public const string dataFileName = "PlayerData_Gamer";

    public static void UpdateUI()
    {
        ClickUpgradesManager.instance.UpdateClickUpgradeUI();
        // Cannot get object cause its in other scene
        // AutoClickerManager.instance.UpdateUpgradeUI();
        PrestigeManager.instance.UpdatePrestigeUpgradeUI();
    }
    private void Start()
    {
        data = SaveSystem.SaveExists(dataFileName)
            ? SaveSystem.LoadData<Data>(dataFileName)
            : new Data();

        ClickUpgradesManager.instance.StartUpgradeManager();
        PrestigeManager.instance.StartPrestigeManager();
    }

    private void Update()
    {
        gamerClickPowerText.text = "+" + ClickPower().ToString(format: "F0") + " Gamers";
        gamersText.text = data.gamers.ToString(format: "F1") + " Gamers";
    }

    public void GenerateGamers()
    {
        data.gamers += ClickPower();
    }
}
