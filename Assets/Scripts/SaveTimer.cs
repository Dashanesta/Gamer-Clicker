using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimer : MonoBehaviour
{
    public static SaveTimer instance;
    private void Awake() => instance = this;
    
    public const string dataFileName = "PlayerData_Gamer";
    public float SaveTime;
    public static void SaveGame()
    {
        SaveSystem.SaveData(Controller.instance.data, dataFileName);
        SaveTimer.instance.SaveTime = 0;
    }
    void Update()
    {
        SaveTime += Time.deltaTime * (1 / Time.timeScale);
        if (SaveTime >= 5)
        {
            SaveGame();
        }
    }
}
