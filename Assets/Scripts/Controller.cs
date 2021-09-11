using UnityEngine;
using TMPro;
using BreakInfinity;


public class Controller : MonoBehaviour
{
    public static Controller instance;
    private void Awake() => instance = this;

    public Data data;

    [SerializeField] private TMP_Text gamersText;
    [SerializeField] private TMP_Text gamerClickPowerText;

    public BigDouble ClickPower() => data.prestigeMultiplier * (1 + data.clickUpgradeLevel);

    private void Start()
    {
        data = new Data();

        UpgradesManager.instance.StartUpgradeManager();
        PrestigeManager.instance.StartPrestigeManager();
    }

    private void Update()
    {
        gamerClickPowerText.text = "+" + ClickPower().ToString(format: "F2") + " Gamers";
        gamersText.text = data.gamers.ToString(format: "F1") + " Gamers";
    }

    public void GenerateGamers()
    {
        data.gamers += ClickPower();
    }
}
