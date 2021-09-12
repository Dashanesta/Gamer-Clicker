using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ShopScene()
    {
        SaveTimer.SaveGame();
        SceneManager.LoadScene("ShopScene");
        //AutoClickerManager.instance.StartUpgradeManager();
    }
    public void ReturnHome()
    {
        SaveTimer.SaveGame();
        SceneManager.LoadScene("MainScene");
    }
}
