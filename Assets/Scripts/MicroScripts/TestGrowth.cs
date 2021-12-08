using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGrowth : MonoBehaviour {
    [SerializeField] private GameObject appleGameObject, appleTree1, appleTree2, appleTree3;
    [SerializeField] private BoxCollider2D fruit;
    bool stage1 = false;
    bool stage2 = false;
    bool stage3 = false;

    bool notPicked = true;
    private float RegrowFruitTimer = 3.0f;
    //regrow 6months ingame = 1800seconds
    private int addFruit;
    public Text fruitText;
    //public Text [] fruitText; ?
    public float inGameTime;
    public float TreeAge = 0;
    //public float TreeDeath = 10000;
    public Text treeAge;

    void Start()
    {
        //if apple tree is chosen:
        //appleGameObject.SetActive(true);
        //fruit.enabled = false;
        //TreeAge += 363;
        treeAge.text = "" + TreeAge + " Days Old";
        //InvokeRepeating("Timer", 10.0f, 10.0f);
        InvokeRepeating("Timer", 1.0f, 0.5f);

        appleTree1.SetActive(false);
        appleTree2.SetActive(false);
        appleTree3.SetActive(false);

        //timerIsRunning = true;
    }
    void Update()
    {
        if (appleGameObject == true) {
            inGameTime += Time.deltaTime;
            //print(inGameTime);
            grow();
        }
    }

    void CollectFruit() {
        addFruit = fruitText.GetComponent<FruitTracker>().apple += Random.Range(400,800);
    }
    void OnMouseDown() {
        if (!Input.GetMouseButtonDown(0)) return;
            CollectFruit();
            notPicked = false;
            stage3 = false;
            fruit.enabled = false;
            stage2 = true;
            StartCoroutine(growstage3()); 
    }

    void grow() {
        //if meets condition then activate
        //Time.timeScale = 1.0f;

        //conditions to activate tree stages
        if(TreeAge < 3){
            stage1 = true;
            //stage2 = false;
            //stage3 = false;
        }
     
        if(TreeAge >= 3) {
            stage1 = false;
            stage2 = true;
            //fruit.enabled = true;
            //stage3 = false;
        }
        if(TreeAge >= 4 && notPicked == true/*&& fruit.enabled == true*/) {
            //stage1 = false;
            fruit.enabled = true;
            stage2 = false;
            stage3 = true; 
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
            appleTree1.SetActive(false);
            appleTree2.SetActive(false);
            appleTree3.SetActive(true);
        }
    }
    
    IEnumerator growstage3() {
        //print("coroutine started");
        //yield return new WaitForSecondsRealtime(2);
        yield return new WaitForSeconds(RegrowFruitTimer);
        notPicked = true;
        stage3 = true;
        stage2 = false;
        fruit.enabled = true; 
        //print("coroutine finished");
    }

    void Timer() {
        //10seconds = 1 day
        //5mins = 1month
        //30mins = 6months
        //1hour = 1year
        //inGameTime += Time.deltaTime;
        TreeAge++;
        if(TreeAge <= 30) {
            treeAge.text = "" + TreeAge + " Days old";
        }
        if(TreeAge >= 30) {
            //treeAge.text = "" + TreeAge / 30 + " Months old";
            treeAge.text = (TreeAge / 30.416).ToString("F1") + " Months old";
        }
        if(TreeAge >= 365) {
            //treeAge.text = "" + TreeAge / 12 + " Years old";
            treeAge.text = (TreeAge / 30.416 / 12).ToString("F1") + " Years old";
        }
        //Tree Death
        //if(TreeAge >= TreeDeath) {
        //    treeAge.text = "Reached <> Years, Tree has died";
        //}        
        //if (currentCoins >= 1000000000) reapcoinDisplay.text = (currentCoins / 1000000000).ToString("F") + "B";
    }
}