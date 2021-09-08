using UnityEngine;
using TMPro;
using BreakInfinity;


public class Controller : MonoBehaviour
{
    public UpgradesManager upgradesManager;
    public Data data;

    [SerializeField] private TMP_Text gamersText;
    [SerializeField] private TMP_Text gamerClickPowerText;

    public BigDouble ClickPower() => 1 + data.clickUpgradeLevel;

    private void Start()
    {
        data = new Data();

        upgradesManager.StartUpgradeManager();
    }

    private void Update()
    {
        gamerClickPowerText.text = "+" + ClickPower() + " Gamers";
        gamersText.text = data.gamers + " Gamers";
    }

    public void GenerateGamers()
    {
        data.gamers += ClickPower();
    }
}
