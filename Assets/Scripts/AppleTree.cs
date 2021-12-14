using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour {
    [SerializeField] private GameObject appleGameObject, appleTree1, appleTree2, appleTree3;
    public BoxCollider2D fruit;
    public static bool stage1 = false;
    public static bool stage2 = false;
    public static bool stage3 = false;
    public static bool stage4 = false;
    bool notPicked = true; 
    private float RegrowFruitTimer = 60.0f; //60.0f
    private int addFruit;
    public Text fruitText;  
    public float inGameTime;
    public float TreeAge = 0;
    public static float TreeDeathAge = 10960f;
    //30 years ingame
    //182mins realtime
    public Text treeAge,TreeType;

    void Start() {
        treeAge.text = "" + TreeAge + " Day old";
        TreeType.text = "Apple Tree";
        InvokeRepeating("Timer", 1.0f, 1.0f);
        appleTree1.SetActive(false);
        appleTree2.SetActive(false);
        appleTree3.SetActive(false);

        if(PlayerPrefs.HasKey("AppleTree")) {
            TreeAge = PlayerPrefs.GetFloat("AppleTree");
            inGameTime = PlayerPrefs.GetFloat("AppleTree");
        }
    }
    void Update() {
        if (appleGameObject) {
            inGameTime += Time.deltaTime;
            PlayerPrefs.SetFloat("AppleTree", inGameTime);
            //print(inGameTime);
            grow();
        }
        if(!Inventory_UI.uiHidden) fruit.enabled = false;
        if(!Task_UI.uiHidden) fruit.enabled = false;
        if(!Shop_UI.uiHidden) fruit.enabled = false;
        if(!industry_UI.uiHidden) fruit.enabled = false;
        if(!Farmer_UI.uiHidden) fruit.enabled = false;
        if(!Help_UI.uiHidden) fruit.enabled = false;
        if(!Store_UI.uiHidden) fruit.enabled = false;

        TreeAge += 0;
        PlayerPrefs.SetFloat("AppleTree", TreeAge);
    }
    public void TreeGrowth() {
        StopCoroutine(growstage3());
        notPicked = true;
        stage3 = true;
        stage2 = false;
        fruit.enabled = true; 
    }
    public void CollectFruit() {
        if(UseItem.FruitbActive) {
            addFruit = fruitText.GetComponent<TrackApples>().apple += Random.Range(800,1200);
            //print("AppleTreeFruitBoosterActive " + addFruit);
        } else {
            //StartCoroutine(delay());
            addFruit = fruitText.GetComponent<TrackApples>().apple += Random.Range(400,800);
            //print("AppleTreeScript " + addFruit);
        }
    }
    public void OnMouseDown() {
        if(gameObject.name == "Apple") {
            CollectFruit();
            notPicked = false;
            stage3 = false;
            fruit.enabled = false;
            stage2 = true;
            StartCoroutine(growstage3());
        } 
    }
    void grow() {
        //conditions to activate tree stages
        if(TreeAge < 3){
            stage1 = true;
        }
        if(TreeAge >= 10) {
            stage1 = false;
            stage2 = true;
        }
        if(TreeAge >= 20 && notPicked == true) {
            fruit.enabled = true;
            stage2 = false;
            stage3 = true; 
        }
        if(TreeAge >= TreeDeathAge) {
            stage3 = false;
            stage4 = true;
        }
        //activates trees when conditions are met
        if (stage1) {
            fruit.enabled = false;
            appleTree1.SetActive(true);
            appleTree2.SetActive(false);
            appleTree3.SetActive(false);
        }
        if (stage2) {
            fruit.enabled = false;
            appleTree1.SetActive(false);
            appleTree2.SetActive(true);
            appleTree3.SetActive(false);
        }
        if (stage3) {
            fruit.enabled = true;
            appleTree2.SetActive(false);
            appleTree3.SetActive(true);
        }
        if(stage4) {
            fruit.enabled = false;
            BuyItem.apple = 0;
            CancelInvoke();
            appleTree1.SetActive(false);
            appleTree2.SetActive(false);
            appleTree3.SetActive(false);
        }
    }
    IEnumerator growstage3() {
        yield return new WaitForSeconds(RegrowFruitTimer);
        notPicked = true;
        stage3 = true;
        stage2 = false;
        fruit.enabled = true; 
    }
    void Timer() {
        //10seconds = 1 day
        //5mins = 1month //300seconds
        //30mins = 6months
        //1hour = 1year
        TreeAge++;
        if(TreeAge <= 30) {
            treeAge.text = "" + TreeAge + " Day old";
        }
        if(TreeAge >= 30) {
            treeAge.text = (TreeAge / 30.416).ToString("F1") + " Month old";
        }
        if(TreeAge >= 365) {
            treeAge.text = (TreeAge / 30.416 / 12).ToString("F1") + " Year old";
        }
        //Tree Death
        if(TreeAge >= TreeDeathAge) {
            SaveGame.apple = 0;
            treeAge.text = "Reached " + TreeAge + " Years";
        }        
    }
    public void reset() {
        TreeAge = 0;
        TreeDeathAge = 10960f;
        inGameTime = 0;
        InvokeRepeating("Timer", 1.0f, 1.0f);
    }
}