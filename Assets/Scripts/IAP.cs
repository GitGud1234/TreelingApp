using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour {
    private string coin1000 = "com.reapsource.treeling.coin1000";
    private string coin5000 = "com.reapsource.treeling.coin5000";
    private string coin10000 = "com.reapsource.treeling.coin10000";
    private string coin20000 = "com.reapsource.treeling.coin20000";
    public int coins1000;
    public int coins5000;
    public int coins10000;
    public int coins20000;

    public Text RC;

    public float coins1;
    public void OnPurchaseComplete1000(Product product)
    {
        if(product.definition.id == coin1000)
        {
            coins1 = RC.GetComponent<CoinText>().currentCoins += 1000;                        
            Debug.Log("You've gained 1000 coins");
        }
    }

    public void OnPurchaseComplete5000(Product product)
    {
        if(product.definition.id == coin5000)
        {
            coins1 = RC.GetComponent<CoinText>().currentCoins += 5000;
            Debug.Log("You've gained 5000 coins");
        }
    }

    public void OnPurchaseComplete10000(Product product)
    {
        if(product.definition.id == coin10000)
        {
            coins1 = RC.GetComponent<CoinText>().currentCoins += 10000;
            Debug.Log("You've gained 10,000 coins");
        }
    }
    public void OnPurchaseComplete20000(Product product)
    {
        if(product.definition.id == coin20000)
        {
            coins1 = RC.GetComponent<CoinText>().currentCoins += 20000;
            Debug.Log("You've gained 20,000 coins");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + "failed because" + failureReason);
    }
}