using UnityEngine;
using TMPro;
using BreakInfinity;


public class Controller : MonoBehaviour
{
    public Data data;

    public TMP_Text gamersText;

    private void Start()
    {
        data = new Data();
    }

    private void Update()
    {
        gamersText.text = data.gamers + " Gamers";
    }

    public void GenerateGamers()
    {
        data.gamers += 1;
    }
}
