using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour {
    public static bool WaterActive;
    public static bool FertiliserActive;
    public static bool FruitbActive;
    public static bool TreegActive;
    [SerializeField] private Image imageCoolDown;
    private bool isCD = false;
    public float CDTime = 100.0f;
    public float CDTimer = 0.0f;
    public Text waterTxt,fertiliserTxt, fruitBTxt, treeGTxt;
    public GameObject active1,active2,active3,active4;
    private bool TreeGrowthUseable;

    void Start() {
       imageCoolDown.fillAmount = 0.0f;
       active1.SetActive(false);
       active2.SetActive(false);
       active3.SetActive(false);
       active4.SetActive(false);
       //if(PlayerPrefs.HasKey("water")) CDTimer = PlayerPrefs.GetFloat("water");
    }

    void Update() {
        if(isCD) applyCooldown();

        condition();
    }
    public void OnMouseDown() {
        if(gameObject.name == "Water") {
            //print("clicked on water");
            if(BuyItem.water < 1) {
                //u dont have any water in inventory
            } else {
            WaterUsed();
            if(isCD) applyCooldown(); 
            WaterActive = true;
            StartCoroutine(WaterTimer());
            //PlayerPrefs.SetFloat("water", CDTimer);
            }
            waterTxt.text = "" + BuyItem.water;
            
        }
        if(gameObject.name == "Fertiliser") {
            //print("clicked on Fertiliser");
             if(BuyItem.fertiliser < 1) {
                //u dont have any water in inventory
            } else {
            FertiliserUsed();
            if(isCD) applyCooldown();
            FertiliserActive = true;
            StartCoroutine(FertiliserTimer());
            }
            fertiliserTxt.text = "" + BuyItem.fertiliser;
        }
        if(gameObject.name == "FruitBooster") {
            //print("clicked on fruitbooster");
             if(BuyItem.fruitB < 1) {
                //u dont have any water in inventory
            } else {
            FruitBUsed();
            if(isCD) applyCooldown();
            //use item
            FruitbActive = true;
            StartCoroutine(FruitbTimer());
            }
            fruitBTxt.text = "" + BuyItem.fruitB;
        }
        if(gameObject.name == "Tree Growth") {
            //print("clicked on tree growth");
            if(BuyItem.treeG < 1) {
                //u dont have any water in inventory
            } else {
            TreeGUsed();
            if(isCD) applyCooldown();
            TreegActive = true;
            StartCoroutine(TreeGTimer());
            }
            treeGTxt.text = "" + BuyItem.treeG;
            //use item
        }
    }
    void applyCooldown() {
        CDTimer -= Time.deltaTime;

        if(CDTimer < 0.0f) {
            isCD = false;
            //textCD.gameObject.SetActive(false);
            imageCoolDown.fillAmount = 0.0f;
        }
        else {
            //textCD.text = Mathf.RoundToInt(CDTimer).ToString();
            imageCoolDown.fillAmount = CDTimer / CDTime;
        }
    }
    public void WaterUsed() {
        if(isCD) {
            //user has clicked item while in cooldown so do nothing
        }
        else {
            BuyItem.water--;
            isCD = true;
            //textCD.gameObject.SetActive(true);
            //waterTimer = CDTime;
            CDTime = 1;
            CDTimer = CDTime;
            active1.SetActive(true);

            //water effects on active trees
            if(SaveGame.apple == 1) AppleTree.TreeDeathAge += 60;
            if(SaveGame.banana == 1) BananaTree.TreeDeathAge += 60;
            if(SaveGame.orange == 1) OrangeTree.TreeDeathAge += 60;
            if(SaveGame.lemon == 1) LemonTree.TreeDeathAge += 60;
            if(SaveGame.coconut == 1) CoconutTree.TreeDeathAge += 60;
            if(SaveGame.cocoa == 1) CocoaTree.TreeDeathAge += 60;
        }
    }
    public void FertiliserUsed() {
        if(isCD) {
            //user has clicked item while in cooldown so do nothing
        }
        else {
            BuyItem.fertiliser--;
            isCD = true;
            //textCD.gameObject.SetActive(true);
            CDTimer = CDTime;
            active2.SetActive(true);
        }
    }
    public void FruitBUsed() {
        if(isCD) {
            //user has clicked item while in cooldown so do nothing
        }
        else {
            BuyItem.fruitB--;
            isCD = true;
            //textCD.gameObject.SetActive(true);
            CDTimer = CDTime;
            active3.SetActive(true);
        }
    }

    void condition() {
        if(AppleTree.stage2 || BananaTree.stage2 || OrangeTree.stage2 || LemonTree.stage2 || CoconutTree.stage2 || CocoaTree.stage2) {
            TreeGrowthUseable = true;
        } else {
            TreeGrowthUseable = false;
        }
    }
    public void TreeGUsed() {
        if(isCD) {
            //user has clicked item while in cooldown so do nothing
        }
        else {

            if(TreeGrowthUseable) {
                BuyItem.treeG--;
                isCD = true;
                CDTime = 1;
                CDTimer = CDTime;
                active4.SetActive(true);

                if(SaveGame.apple == 1 && AppleTree.stage2){
                    AppleTree treeG = FindObjectOfType<AppleTree>();
                    treeG.TreeGrowth();
                }
                if(SaveGame.banana == 1 && BananaTree.stage2){
                    BananaTree treeG = FindObjectOfType<BananaTree>();
                    treeG.TreeGrowth();
                }
                if(SaveGame.orange == 1 && OrangeTree.stage2){
                    OrangeTree treeG = FindObjectOfType<OrangeTree>();
                    treeG.TreeGrowth();
                }
                if(SaveGame.lemon == 1 && LemonTree.stage2){
                    LemonTree treeG = FindObjectOfType<LemonTree>();
                    treeG.TreeGrowth();
                }
                if(SaveGame.coconut == 1 && CoconutTree.stage2){
                    CoconutTree treeG = FindObjectOfType<CoconutTree>();
                    treeG.TreeGrowth();
                }
                if(SaveGame.cocoa == 1 && CocoaTree.stage2){
                    CocoaTree treeG = FindObjectOfType<CocoaTree>();
                    treeG.TreeGrowth();
                }
            }
        }
    }

    IEnumerator WaterTimer() {
        yield return new WaitForSeconds(CDTime);
        WaterActive = false;
        active1.SetActive(false);
    }

    IEnumerator FertiliserTimer() {
        yield return new WaitForSeconds(CDTime);
        FertiliserActive = false;
        active2.SetActive(false);
    }
    IEnumerator FruitbTimer() {
        yield return new WaitForSeconds(CDTime);
        FruitbActive = false;
        active3.SetActive(false);
    }
    IEnumerator TreeGTimer() {
        yield return new WaitForSeconds(CDTime);
        TreegActive = false;
        active4.SetActive(false);
    }
}