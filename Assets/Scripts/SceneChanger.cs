using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ShopScene()
    {
        Controller.SaveGame();
        SceneManager.LoadScene("ShopScene");
        //AutoClickerManager.instance.StartUpgradeManager();
    }
    public void ReturnHome()
    {
        Controller.SaveGame();
        SceneManager.LoadScene("MainScene");
    }
}
