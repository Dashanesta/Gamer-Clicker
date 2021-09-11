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

    public const string dataFileName = "PlayerData_Gamer";

    private void Start()
    {
        data = SaveSystem.SaveExists(dataFileName)
            ? SaveSystem.LoadData<Data>(dataFileName)
            : new Data();

        UpgradesManager.instance.StartUpgradeManager();
        PrestigeManager.instance.StartPrestigeManager();
    }

    public float SaveTime;

    // Function to save the game publicly
    public static void SaveGame()
    {
        SaveSystem.SaveData(Controller.instance.data, dataFileName);
        Controller.instance.SaveTime = 0;
    }

    private void Update()
    {
        gamerClickPowerText.text = "+" + ClickPower().ToString(format: "F2") + " Gamers";
        gamersText.text = data.gamers.ToString(format: "F1") + " Gamers";

        // Autosaves game every 5 seconds
        SaveTime += Time.deltaTime * (1 / Time.timeScale);
        if (SaveTime >= 5)
        {
            SaveGame();
        }
    }

    public void GenerateGamers()
    {
        data.gamers += ClickPower();
    }
}
