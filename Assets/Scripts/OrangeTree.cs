using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OrangeTree : MonoBehaviour {
    [SerializeField] private GameObject orangeGameObject, orangeTree1, orangeTree2, orangeTree3;
    [SerializeField] private BoxCollider2D fruit;
    bool stage1 = false;
    bool stage2 = false;
    public static bool stage3 = false;
    bool notPicked = true;
    private float RegrowFruitTimer = 60.0f;  
    private int addFruit;
    public Text fruitText;  
    public float inGameTime;
    public float TreeAge = 0;
    public Text treeAge,TreeType;
    void Start() {
        treeAge.text = "" + TreeAge + " Day old";
        TreeType.text = "Orange Tree";
        //InvokeRepeating("Timer", 10.0f, 10.0f);
        //Testing below
        InvokeRepeating("Timer", 1.0f, 1.0f);

        orangeTree1.SetActive(false);
        orangeTree2.SetActive(false);
        orangeTree3.SetActive(false);

        if (PlayerPrefs.HasKey("OrangeTree")) {
            TreeAge = PlayerPrefs.GetFloat("OrangeTree");
        }
    }

    void Update() {
        if (orangeGameObject == true) {
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
        PlayerPrefs.SetFloat("OrangeTree", TreeAge);
    }
    void CollectFruit() {
        if(UseItem.FruitbActive) {
            addFruit = fruitText.GetComponent<TrackOranges>().orange += Random.Range(400,600);
        } else {
            addFruit = fruitText.GetComponent<TrackOranges>().orange += Random.Range(200,350);
        }
    } 
    public void OnMouseDown() {
        if(gameObject.name == "Orange"){
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
        //activates trees when conditions are met
        if (stage1) {
            fruit.enabled = false;
            orangeTree1.SetActive(true);
            orangeTree2.SetActive(false);
            orangeTree3.SetActive(false);
        }
        if (stage2) {
            fruit.enabled = false;
            orangeTree1.SetActive(false);
            orangeTree2.SetActive(true);
            orangeTree3.SetActive(false);
        }
        if (stage3) {
            fruit.enabled = true;
            orangeTree1.SetActive(false);
            orangeTree2.SetActive(false);
            orangeTree3.SetActive(true);
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
        //5mins = 1month
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
        //if(TreeAge >= TreeDeath) {
        //    treeAge.text = "Reached <> Years, Tree has died";
        //}        
    }
}