using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour {
    public Text reapcoinDisplay;
    public float currentCoins = 0;
    double DCoins;
    public Text InventoryDisplay;
    public Text ShopDisplay;
    public Text IndustryDisplay;

    void Start() {
        //stores player coin data
        if(PlayerPrefs.HasKey("CoinSystem")) currentCoins = PlayerPrefs.GetFloat("CoinSystem");
    }
    void Update() {
        //Testing purposes
        //if(Input.GetKeyDown("w")) {
        //    currentCoins += 1000000;
        //}
        
        if (currentCoins >= 1000000000) reapcoinDisplay.text = (currentCoins / 1000000000).ToString("F") + "B"; //1B, 10B, 100B...
        else if (currentCoins >= 1000000) reapcoinDisplay.text = (currentCoins / 1000000).ToString("F") + "M"; //1M, 10M, 100M
        else if (currentCoins >= 1000) reapcoinDisplay.text = (currentCoins / 1000).ToString("F") + "K"; //1K, 10k, 100K
        else if (currentCoins < 1000) reapcoinDisplay.text = currentCoins.ToString(); //0-999
        
        InventoryDisplay.text = "ReapCoins: " + (double)currentCoins;
        ShopDisplay.text = "ReapCoins: " + (double)currentCoins;
        IndustryDisplay.text = "ReapCoins: " + (double)currentCoins;

        //saves coin data
        PlayerPrefs.SetFloat("CoinSystem", currentCoins);
    }
}