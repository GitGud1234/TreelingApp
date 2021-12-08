using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellFruit : MonoBehaviour {
    //prices of each fruit
    float applePrice = 2; 
    float bananaPrice = 40;
    float orangePrice = 3; 
    float lemonPrice = 1;
    float coconutPrice = 10; 
    float cocoaPrice = 1;

    float appleAmount, bananaAmount, orangeAmount, lemonAmount, coconutAmount, cocoaAmount;

    public float appleSell, bananaSell, orangeSell, lemonSell, coconutSell, cocoaSell;

    float appleC, bananaC, orangeC, lemonC, coconutC, cocoaC;
    
    public Text appleTxt,bananaTxt,orangeTxt,lemonTxt,coconutTxt,cocoaTxt;
    public Text RCText;
    public Text appleRC, bananaRC, orangeRC, lemonRC, coconutRC, cocoaRC;
    public Text appleA,bananaA, orangeA, lemonA, coconutA, cocoaA;
    private float appleNum,bananaNum,orangeNum, lemonNum, coconutNum, cocoaNum;
    private float coins;

    void Start() {
        if (PlayerPrefs.HasKey("Anumber")) appleNum = PlayerPrefs.GetFloat("Anumber");
        
        if(PlayerPrefs.HasKey("AppleS")) appleC = PlayerPrefs.GetFloat("AppleS");
        
        if(PlayerPrefs.HasKey("Bnumber")) bananaNum = PlayerPrefs.GetFloat("Bnumber");
        
        if (PlayerPrefs.HasKey("BananaS")) bananaC = PlayerPrefs.GetFloat("BananaS");
        
        if (PlayerPrefs.HasKey("Onumber")) orangeNum = PlayerPrefs.GetFloat("Onumber");
        
        if (PlayerPrefs.HasKey("OrangeS")) orangeC = PlayerPrefs.GetFloat("OrangeS");
        
        if (PlayerPrefs.HasKey("Lnumber")) lemonNum = PlayerPrefs.GetFloat("Lnumber");
        
        if (PlayerPrefs.HasKey("LemonS")) lemonC = PlayerPrefs.GetFloat("LemonS");
        
        if (PlayerPrefs.HasKey("Cnumber")) coconutNum = PlayerPrefs.GetFloat("Cnumber");
        
        if (PlayerPrefs.HasKey("CoconutS")) coconutC = PlayerPrefs.GetFloat("CoconutS");
        
        if (PlayerPrefs.HasKey("COnumber")) cocoaNum = PlayerPrefs.GetFloat("COnumber");
        
        if (PlayerPrefs.HasKey("CocoaS")) cocoaC = PlayerPrefs.GetFloat("CocoaS");
    }

    public void sellFruit() {
        //fruit booster x2
        if(UseItem.FertiliserActive) {
            appleSell = (applePrice * (2.0f)) * appleAmount;
            bananaSell = (bananaPrice * (2.0f)) * bananaAmount;
            orangeSell = (orangePrice * (2.0f)) * orangeAmount;
            lemonSell = (lemonPrice * (2.0f)) * lemonAmount;
            coconutSell = (coconutPrice * (2.0f)) * coconutAmount;
            cocoaSell = (cocoaPrice * (2.0f)) * cocoaAmount;
        } else {
            appleSell = applePrice * appleAmount;
            bananaSell = bananaPrice * bananaAmount;
            orangeSell = orangePrice * orangeAmount;
            lemonSell = lemonPrice * lemonAmount;
            coconutSell = coconutPrice * coconutAmount;
            cocoaSell = cocoaPrice * cocoaAmount;
        }
        coins = RCText.GetComponent<CoinText>().currentCoins += (appleSell
        + bananaSell + orangeSell + lemonSell + coconutSell + cocoaSell);

        applecalc();
        bananacalc();
        orangeCalc();
        lemonCalc();
        coconutCalc();
        cocoaCalc();

        appleAmount = appleTxt.GetComponent<TrackApples>().apple = 0;
        bananaAmount = bananaTxt.GetComponent<TrackBananas>().banana = 0;
        orangeAmount = orangeTxt.GetComponent<TrackOranges>().orange = 0;
        lemonAmount = lemonTxt.GetComponent<TrackLemons>().lemon = 0;
        coconutAmount = coconutTxt.GetComponent<TrackCoconuts>().coconut = 0;
        cocoaAmount = cocoaTxt.GetComponent<TrackCocoa>().cocoa = 0;
    }
    void Update() {
        appleAmount = appleTxt.GetComponent<TrackApples>().apple;
        bananaAmount = bananaTxt.GetComponent<TrackBananas>().banana;
        orangeAmount = orangeTxt.GetComponent<TrackOranges>().orange;
        lemonAmount = lemonTxt.GetComponent<TrackLemons>().lemon;
        coconutAmount = coconutTxt.GetComponent<TrackCoconuts>().coconut;
        cocoaAmount = cocoaTxt.GetComponent<TrackCocoa>().cocoa;

        coins = RCText.GetComponent<CoinText>().currentCoins;

        appleA.text = "" + appleNum;
        appleNum += 0;
        PlayerPrefs.SetFloat ("Anumber", appleNum);

        appleRC.text = "" + appleC;
        appleC += 0;
        PlayerPrefs.SetFloat("AppleS", appleC);

        bananaA.text = "" + bananaNum;
        bananaNum += 0;
        PlayerPrefs.SetFloat("Bnumber", bananaNum);

        bananaRC.text = "" + bananaC;
        bananaC += 0;
        PlayerPrefs.SetFloat("BananaS", bananaC);
        
        orangeA.text = "" + orangeNum;
        orangeNum += 0;
        PlayerPrefs.SetFloat("Onumber", orangeNum);

        orangeRC.text = "" + orangeC;
        orangeC += 0;
        PlayerPrefs.SetFloat("OrangeS", orangeC);

        lemonA.text = "" + lemonNum;
        lemonNum += 0;
        PlayerPrefs.SetFloat("Lnumber", lemonNum);

        lemonRC.text = "" + lemonC;
        lemonC += 0;
        PlayerPrefs.SetFloat("LemonS", lemonC);

        coconutA.text = "" + coconutNum;
        coconutNum += 0;
        PlayerPrefs.SetFloat("Cnumber", coconutNum);

        coconutRC.text = "" + coconutC;
        coconutC += 0;
        PlayerPrefs.SetFloat("CoconutS", coconutC);

        cocoaA.text = "" + cocoaNum;
        cocoaNum += 0;
        PlayerPrefs.SetFloat("COnumber", cocoaNum);

        cocoaRC.text = "" + cocoaC;
        cocoaC += 0;
        PlayerPrefs.SetFloat("CocoaS", cocoaC);
    }
    void applecalc() {
        float a = appleC; 
        float b = appleSell + a;
        appleC = b;
        appleRC.text = "" + appleC;

        float c = appleNum;
        float d = appleAmount + c;
        appleNum = d;
        appleA.text = "" + appleNum;
    }
    void bananacalc() {
        float a = bananaC; 
        float b = bananaSell + a;
        bananaC = b;
        bananaRC.text = "" + bananaC;

        float c = bananaNum;
        float d = bananaAmount + c;
        bananaNum = d;
        bananaA.text = "" + bananaNum;
    }
    void orangeCalc() {
        float a = orangeC;
        float b = orangeSell + a;
        orangeC = b;
        orangeRC.text = "" + orangeC;

        float c = orangeNum;
        float d = orangeAmount + c;
        orangeNum = d;
        orangeA.text = "" + orangeNum;
    }
    void lemonCalc() {
        float a = lemonC;
        float b = lemonSell + a;
        lemonC = b;
        lemonRC.text = "" + lemonC;
        
        float c = lemonNum;
        float d = lemonAmount + c;
        lemonNum = d;
        lemonA.text = "" + lemonNum;
    }   
    void coconutCalc() {
        float a = coconutC;
        float b = coconutSell + a;
        coconutC = b;
        coconutRC.text = "" + coconutC;

        float c = coconutNum;
        float d = coconutAmount + c;
        coconutNum = d;
        coconutA.text = "" + coconutNum;
    }
    void cocoaCalc() {
        float a = cocoaC;
        float b = cocoaSell + a;
        cocoaC = b;
        cocoaA.text = "" + cocoaC;

        float c = cocoaNum;
        float d = cocoaAmount + c;
        cocoaNum = d;
        cocoaA.text = "" + cocoaNum;
    }
}