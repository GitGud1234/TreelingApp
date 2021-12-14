using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaTree : MonoBehaviour {
    [SerializeField] private GameObject bananaGameObject, bananaTree1, bananaTree2, bananaTree3;
    [SerializeField] public BoxCollider2D fruit;
    public static bool stage1 = false;
    public static bool stage2 = false;
    public static bool stage3 = false;
    public static bool stage4 = false;
    bool notPicked = true;
    private float RegrowFruitTimer = 60.0f;  
    private int addFruit;
    public Text fruitText;  
    public float inGameTime;
    public float TreeAge = 0;
    public static float TreeDeathAge = 2191f; 
    //6 years ingame time
    //36mins30seconds real time

    public Text treeAge,TreeType;
    void Start() {
        treeAge.text = "" + TreeAge + " Day old";
        TreeType.text = "Banana Tree";
        InvokeRepeating("Timer", 1.0f, 1.0f);
        bananaTree1.SetActive(false);
        bananaTree2.SetActive(false);
        bananaTree3.SetActive(false);
        
        if (PlayerPrefs.HasKey("BananaTree")) {
            TreeAge = PlayerPrefs.GetFloat("BananaTree");
            inGameTime = PlayerPrefs.GetFloat("BananaTree");
        }
    }
    void Update() {
        if (bananaGameObject) {
            inGameTime += Time.deltaTime;
            PlayerPrefs.SetFloat("BananaTree", inGameTime);
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
        PlayerPrefs.SetFloat("BananaTree", TreeAge);
    }
    public void TreeGrowth() {
        StopCoroutine(growstage3());
        notPicked = true;
        stage3 = true;
        stage2 = false;
        fruit.enabled = true; 
    }
    void CollectFruit() {
        if(UseItem.FruitbActive) {
            addFruit = fruitText.GetComponent<TrackBananas>().banana += Random.Range(120,240);
        } else {
            addFruit = fruitText.GetComponent<TrackBananas>().banana += Random.Range(60,120);
        }
    }
    public void OnMouseDown() {
        if(gameObject.name == "Banana"){
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
            bananaTree1.SetActive(true);
            bananaTree2.SetActive(false);
            bananaTree3.SetActive(false);
        }
        if (stage2) {
            fruit.enabled = false;
            bananaTree1.SetActive(false);
            bananaTree2.SetActive(true);
            bananaTree3.SetActive(false);
        }
        if (stage3) {
            fruit.enabled = true;
            bananaTree1.SetActive(false);
            bananaTree2.SetActive(false);
            bananaTree3.SetActive(true);
        }
        if(stage4) {
            fruit.enabled = false;
            BuyItem.banana = 0;
            //bananaGameObject.SetActive(!bananaGameObject.activeInHierarchy);
            //bananaGameObject.SetActive(false);
            CancelInvoke();
            bananaTree1.SetActive(false);
            bananaTree2.SetActive(false);
            bananaTree3.SetActive(false);
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
        //1second = 1 day
        //1min = 60 days
        //365.25 seconds = 1 year
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
            treeAge.text = "Reached " + TreeAge + " Years";
        }        
    }
    public void reset() {
        TreeAge = 0;
        InvokeRepeating("Timer", 1.0f, 1.0f);
    }
}