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

    private const string dataFileName = "PlayerData_Gamer";

    private void Start()
    {
        data = SaveSystem.SaveExists(dataFileName)
            ? SaveSystem.LoadData<Data>(dataFileName)
            : new Data();

        UpgradesManager.instance.StartUpgradeManager();
        PrestigeManager.instance.StartPrestigeManager();
    }

    public float SaveTime;
    private void Update()
    {
        gamerClickPowerText.text = "+" + ClickPower().ToString(format: "F2") + " Gamers";
        gamersText.text = data.gamers.ToString(format: "F1") + " Gamers";

        SaveTime += Time.deltaTime * (1 / Time.timeScale);
        if (SaveTime >= 5)
        {
            SaveSystem.SaveData(data, dataFileName);
            SaveTime = 0;
        }
    }

    public void GenerateGamers()
    {
        data.gamers += ClickPower();
    }
}
