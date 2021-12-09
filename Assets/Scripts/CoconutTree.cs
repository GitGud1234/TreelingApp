using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoconutTree : MonoBehaviour {
    [SerializeField] private GameObject coconutGameObject, coconutTree1, coconutTree2, coconutTree3;
    [SerializeField] private BoxCollider2D fruit;
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
    private float TreeDeathAge = 10957.5f;
    //30 years ingame
    //182mins realtime
    public Text treeAge,treeType;
    void Start() {
        treeAge.text = "" + TreeAge + " Day old";
        treeType.text = "Coconut Tree";
        InvokeRepeating("Timer", 1.0f, 1.0f);
        coconutTree1.SetActive(false);
        coconutTree2.SetActive(false);
        coconutTree3.SetActive(false);

        if (PlayerPrefs.HasKey("CoconutTree")) {
            TreeAge = PlayerPrefs.GetFloat("CoconutTree");
            inGameTime = PlayerPrefs.GetFloat("CoconutTree");
        }
    }
    void Update() {
        if (coconutGameObject == true) {
            inGameTime += Time.deltaTime;
            PlayerPrefs.SetFloat("CoconutTree",inGameTime);
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
        PlayerPrefs.SetFloat("CoconutTree", TreeAge);
    }
    void CollectFruit() {
        if(UseItem.FruitbActive) {
            addFruit = fruitText.GetComponent<TrackCoconuts>().coconut += Random.Range(100,150);
        }
        else {
            addFruit = fruitText.GetComponent<TrackCoconuts>().coconut += Random.Range(70,100);
        }
    }
    public void OnMouseDown() {
        if(gameObject.name == "Coconut"){
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
            coconutTree1.SetActive(true);
            coconutTree2.SetActive(false);
            coconutTree3.SetActive(false);
        }
        if (stage2) {
            fruit.enabled = false;
            coconutTree1.SetActive(false);
            coconutTree2.SetActive(true);
            coconutTree3.SetActive(false);
        }
        if (stage3) {
            fruit.enabled = true;
            coconutTree1.SetActive(false);
            coconutTree2.SetActive(false);
            coconutTree3.SetActive(true);
        }
        if(stage4) {
            fruit.enabled = false;
            BuyItem.coconut = 0;
        
            CancelInvoke();
            coconutTree1.SetActive(false);
            coconutTree2.SetActive(false);
            coconutTree3.SetActive(false);
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