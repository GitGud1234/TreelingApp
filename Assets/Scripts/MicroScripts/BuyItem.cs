using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyItem : MonoBehaviour {
    public Text RCText;
    public Text textcolor;
    public GameObject RC;
    private float coins;
    public static int apple,banana,orange,lemon,coconut,cocoa;

    //public bool island1,island2,island3,island4,island5,island6 = false;
    //public GameObject island1,island2,island3,island4,island5,island6;
    //public GameObject bananaObject;
    public static int water = 0, fertiliser = 0, fruitB = 0, treeG = 0;
    public Text waterTxt,fertiliserTxt, fruitBTxt, treeGTxt;
    void Start() {
        if (PlayerPrefs.HasKey("Fertiliser")) fertiliser = PlayerPrefs.GetInt("Fertiliser");
        if (PlayerPrefs.HasKey("FruitB")) fruitB = PlayerPrefs.GetInt("FruitB");
        if (PlayerPrefs.HasKey("Water")) water = PlayerPrefs.GetInt("Water");
        if (PlayerPrefs.HasKey("TreeG")) treeG = PlayerPrefs.GetInt("TreeG");
    }
    
    void Update() {
        coins = RCText.GetComponent<CoinText>().currentCoins;
        
        fertiliserTxt.text = "" + fertiliser;
        fertiliser += 0;
        PlayerPrefs.SetInt("Fertiliser", fertiliser);

        fruitBTxt.text = "" + fruitB;
        fruitB += 0;
        PlayerPrefs.SetInt("FruitB", fruitB);

        waterTxt.text = "" + water;
        water += 0;
        PlayerPrefs.SetInt("Water", water);

        treeGTxt.text = "" + treeG;
        treeG += 0;
        PlayerPrefs.SetInt("TreeG", treeG);
    }
    public void buyWater() {
        if(coins < 5000) {
            coins = RCText.GetComponent<CoinText>().currentCoins;
            //print("not enough RC!");
            StartCoroutine(ChangeColor());
        } 
        else{
            coins = RCText.GetComponent<CoinText>().currentCoins -= 5000;
            water++;
            waterTxt.text = "" + water;
        }
    }
    public void buyFertiliser() {
        if(coins < 10000) {
            coins = RCText.GetComponent<CoinText>().currentCoins;
            //print("not enough RC!");
            StartCoroutine(ChangeColor());
        } 
        else{
            coins = RCText.GetComponent<CoinText>().currentCoins -= 10000;
            fertiliser++;
            fertiliserTxt.text = "" + fertiliser;
        }
    }
    public void buyFruitB() {
        if(coins < 10000) {
            coins = RCText.GetComponent<CoinText>().currentCoins;
            //print("not enough RC!");
            StartCoroutine(ChangeColor());
        } 
        else{
            coins = RCText.GetComponent<CoinText>().currentCoins -= 10000;
            fruitB++;
            fruitBTxt.text = "" + fruitB;
        }
    }
    public void buyTreeG() {
        if(coins < 10000) {
            coins = RCText.GetComponent<CoinText>().currentCoins;
            //print("not enough RC!");
            StartCoroutine(ChangeColor());
        } 
        else{
            coins = RCText.GetComponent<CoinText>().currentCoins -= 10000;
            treeG++;
            treeGTxt.text = "" + treeG;
        }
    }
    //activateTree.activateAppleTree = true; // use this for when u start the game

    public void BuyAppleTree() {
        //costs 50k
        //should be setactive false by default, when purchased should be setactive true
        //you can only buy once and have to wait until tree expires before u can buy it again
        //apple = 1;
        //you start the game off with an apple tree!
        if(apple == 0) {
            activateTree.activateAppleTree = false;
        }
        if(apple == 1) {
            activateTree.activateAppleTree = true;
        }
        if(apple >= 2) {
            apple = 1;
        }
        if(coins > 49999 && apple == 0) {
            //purchased
            AppleTree reset = FindObjectOfType<AppleTree>();
            reset.reset();
            AppleTree.stage1 = true;
            AppleTree.stage4 = false;

            activateTree.activateAppleTree = true;
            coins = RCText.GetComponent<CoinText>().currentCoins -= 50000;
            apple = 1;
            //print("apple tree bought");
            PlayerPrefs.SetInt("Apple", SaveGame.apple);
        }
        if(coins < 50000 && apple == 0) {
            //not purchased
            coins = RCText.GetComponent<CoinText>().currentCoins;
            StartCoroutine(ChangeColor());
        }
        if(apple == 1) {
            //already owned
            //print("APPLE ISLAND ALREADY OWNED");
        }
    }
    public void BuyBananaTree() {
        //costs 20k
        if(banana == 0) {
            activateTree.activateBananaTree = false;
        }
        if(banana == 1) {
            activateTree.activateBananaTree = true;
        }
        if(banana >= 2) {
            banana = 1;
        }
        if(coins > 19999 && banana == 0) {
            //purchased
            BananaTree reset = FindObjectOfType<BananaTree>();
            reset.reset();
            BananaTree.stage1 = true;
            BananaTree.stage4 = false;

            activateTree.activateBananaTree = true;
            coins = RCText.GetComponent<CoinText>().currentCoins -= 20000;
            banana = 1;
            SaveGame.banana = 1;
            PlayerPrefs.SetInt("Banana", SaveGame.banana);
        }
        if(coins < 20000 && banana == 0) {
            //not purchased
            coins = RCText.GetComponent<CoinText>().currentCoins;
            StartCoroutine(ChangeColor());
        }
        if(banana == 1) {
            //already owned         
        }       
    }
    public void BuyOrangeTree() {
        //costs 50k
        if(orange == 0) {
            activateTree.activateOrangeTree = false;
        }
        if(orange == 1) {
            activateTree.activateOrangeTree = true;
        }
        if(orange >= 2) {
            orange = 1;
        }
        if(coins > 49999 && orange == 0) {
            //purchased
            OrangeTree reset = FindObjectOfType<OrangeTree>();
            reset.reset();
            OrangeTree.stage1 = true;
            OrangeTree.stage4 = false;

            activateTree.activateOrangeTree = true;
            coins = RCText.GetComponent<CoinText>().currentCoins -= 50000;
            orange = 1;
            SaveGame.orange = 1;
            PlayerPrefs.SetInt("Orange", SaveGame.orange);
        }
        if(coins < 50000 && orange == 0) {
            //not purchased
            coins = RCText.GetComponent<CoinText>().currentCoins;
            StartCoroutine(ChangeColor());
        }
        if(orange == 1) {
            //already owned do nothing
        }
    }
    public void BuyLemonTree() {
        //costs 50k
        if(lemon == 0) {
            activateTree.activateLemonTree = false;
        }
        if(lemon == 1) {
            activateTree.activateLemonTree = true;
        }
        if(lemon >= 2) {
            lemon = 1;
        }
        if(coins > 49999 && lemon == 0) {
            //purchased
            LemonTree reset = FindObjectOfType<LemonTree>();
            reset.reset();
            LemonTree.stage1 = true;
            LemonTree.stage4 = false;

            activateTree.activateLemonTree = true;
            coins = RCText.GetComponent<CoinText>().currentCoins -= 50000;
            lemon = 1;
            SaveGame.lemon = 1;
            PlayerPrefs.SetInt("Lemon", SaveGame.lemon);
        }
        if(coins < 50000 && lemon == 0) {
            //not purchased
            coins = RCText.GetComponent<CoinText>().currentCoins;
            StartCoroutine(ChangeColor());
        }
        if(lemon == 1) {
            //already owned
        }
    }
    public void BuyCoconutTree() {
        //costs 20k
        if(coconut == 0) {
            activateTree.activateCoconutTree = false;
        }
        if(coconut == 1) {
            activateTree.activateCoconutTree = true;
        }
        if(coconut >= 2) {
           coconut = 1;
        }
        if(coins > 19999 && coconut == 0) {
            //purchased
            CoconutTree reset = FindObjectOfType<CoconutTree>();
            reset.reset();
            CoconutTree.stage1 = true;
            CoconutTree.stage4 = false;

            activateTree.activateCoconutTree  = true;
            coins = RCText.GetComponent<CoinText>().currentCoins -= 20000;
            coconut = 1;
            SaveGame.coconut = 1;
            PlayerPrefs.SetInt("Coconut", SaveGame.coconut);
        }
        if(coins < 20000 && coconut == 0) {
            //not purchased
            coins = RCText.GetComponent<CoinText>().currentCoins;
            StartCoroutine(ChangeColor());
        }
        if(coconut == 1) {
            //already owned
        }
    }
    public void BuyCocoaTree() {
        //costs 60k
       if(cocoa == 0) {
            activateTree.activateCocoaTree = false;
        }
        if(cocoa == 1) {
            activateTree.activateCocoaTree = true;
        }
        if(cocoa >= 2) {
           cocoa = 1;
        }
        if(coins > 59999 && cocoa == 0) {
            //purchased
            CocoaTree reset = FindObjectOfType<CocoaTree>();
            reset.reset();
            CocoaTree.stage1 = true;
            CocoaTree.stage4 = false;

            activateTree.activateCocoaTree  = true;
            coins = RCText.GetComponent<CoinText>().currentCoins -= 60000;
            cocoa = 1;
            SaveGame.cocoa = 1;
            PlayerPrefs.SetInt("Cocoa", SaveGame.cocoa);
        }
        if(coins < 60000 && cocoa == 0) {
            //not purchased
            coins = RCText.GetComponent<CoinText>().currentCoins;
            StartCoroutine(ChangeColor());
        }
        if(cocoa == 1) {
            //already owned
        }
    }
    private IEnumerator ChangeColor () {
         textcolor.GetComponent<Text>().color = Color.red;
         yield return new WaitForSeconds(0.2f);
         textcolor.GetComponent<Text>().color = Color.black;
    }
}