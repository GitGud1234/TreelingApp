using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CocoaTree : MonoBehaviour {
    [SerializeField] private GameObject cocoaGameObject, cocoaTree1, cocoaTree2, cocoaTree3;
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
    private float TreeDeathAge = 3652.5f;
    public Text treeAge,treeType;
    void Start() {
        treeAge.text = "" + TreeAge + " Day old";
        treeType.text = "Cocoa Tree";
        InvokeRepeating("Timer", 1.0f, 1.0f);
        cocoaTree1.SetActive(false);
        cocoaTree2.SetActive(false);
        cocoaTree3.SetActive(false);

        if (PlayerPrefs.HasKey("CocoaTree")) {
            TreeAge = PlayerPrefs.GetFloat("CocoaTree");
            inGameTime = PlayerPrefs.GetFloat("CocoaTree");
        }
    }
    void Update() {
        if (cocoaGameObject == true) {
            inGameTime += Time.deltaTime;
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
        PlayerPrefs.SetFloat("CocoaTree", TreeAge);
    }
    void CollectFruit() {
        if(UseItem.FruitbActive) {
            addFruit = fruitText.GetComponent<TrackCocoa>().cocoa += Random.Range(2000,2800);
        } else {
            addFruit = fruitText.GetComponent<TrackCocoa>().cocoa += Random.Range(1200,2000);
        }
    } 
   public void OnMouseDown() {
        if(gameObject.name == "Cocoa"){
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
            cocoaTree1.SetActive(true);
            cocoaTree2.SetActive(false);
            cocoaTree3.SetActive(false);
        }
        if (stage2) {
            fruit.enabled = false;
            cocoaTree1.SetActive(false);
            cocoaTree2.SetActive(true);
            cocoaTree3.SetActive(false);
        }
        if (stage3) {
            fruit.enabled = true;
            cocoaTree1.SetActive(false);
            cocoaTree2.SetActive(false);
            cocoaTree3.SetActive(true);
        }
        if(stage4) {
            fruit.enabled = false;
            BuyItem.cocoa = 0;
            CancelInvoke();
            cocoaTree1.SetActive(false);
            cocoaTree2.SetActive(false);
            cocoaTree3.SetActive(false);
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