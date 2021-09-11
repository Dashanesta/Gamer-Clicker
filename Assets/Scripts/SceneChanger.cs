using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ShopScene() => SceneManager.LoadScene("ShopScene");
    public void ReturnHome() => SceneManager.LoadScene("MainScene");
}
