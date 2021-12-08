using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmerAutomation : MonoBehaviour {
    public Text RCText;
    public GameObject RC;
    private float coins;
    private bool autoHarvest = false;
    [SerializeField] private Image imageCD;
    private bool isCD = false;
    private float CDTime = 3600.0f; //60min active
    private float CDTimer = 0.0f;
    public GameObject activeImage;

    void Start() {
        imageCD.fillAmount = 0.0f;
        activeImage.SetActive(false);
    }

    void Update() {
        if(isCD) {
            applyCooldown();
        }
        coins = RCText.GetComponent<CoinText>().currentCoins;
        harvest();
    }
    void applyCooldown() {
        CDTimer -= Time.deltaTime;

        if(CDTimer < 0.0f) {
            isCD = false;
            imageCD.fillAmount = 0.0f;
            activeImage.SetActive(false);
        }
        else {
            imageCD.fillAmount = CDTimer / CDTime;
            activeImage.SetActive(true);
        }
    }
    public void harvestUsed() {
        if(!isCD) {
            isCD = true;
            CDTimer = CDTime;
        }
    }

    public void OnMouseDown() {
        if(gameObject.name == "AutoHarvest") {
            if(coins < 50000) {
                coins = RCText.GetComponent<CoinText>().currentCoins;
            } else {
                coins = RCText.GetComponent<CoinText>().currentCoins -= 50000;
                autoHarvest = true;
                harvestUsed();
                if(isCD) applyCooldown(); 
                StartCoroutine(harvestTimer());
            }
        }
    }
    IEnumerator harvestTimer() {
        yield return new WaitForSeconds(CDTime);
        autoHarvest = false;
    }
    void harvest() {
        if(autoHarvest && AppleTree.stage3) StartCoroutine(collectApple());
        if(autoHarvest && BananaTree.stage3) StartCoroutine(collectBanana());
        if(autoHarvest && OrangeTree.stage3) StartCoroutine(collectOrange());
        if(autoHarvest && LemonTree.stage3) StartCoroutine(collectLemon());
        if(autoHarvest && CoconutTree.stage3) StartCoroutine(collectCoconut());
        if(autoHarvest && CocoaTree.stage3) StartCoroutine(collectCocoa());
    }
    IEnumerator collectApple() {
        yield return new WaitForSeconds(0.4f);
        if(AppleTree.stage3) {
            AppleTree collect = FindObjectOfType<AppleTree>();
            collect.OnMouseDown();
        }
    }
    IEnumerator collectBanana() {
        yield return new WaitForSeconds(0.4f);
        if(BananaTree.stage3) {
            BananaTree collect = FindObjectOfType<BananaTree>();
            collect.OnMouseDown();
        }
    }
    IEnumerator collectOrange() {
        yield return new WaitForSeconds(0.4f);
        if(OrangeTree.stage3) {
            OrangeTree collect = FindObjectOfType<OrangeTree>();
            collect.OnMouseDown();  
        }
    }
    IEnumerator collectLemon() {
        yield return new WaitForSeconds(0.4f);
        if(LemonTree.stage3) {
            LemonTree collect = FindObjectOfType<LemonTree>();
            collect.OnMouseDown();
        }
    }
    IEnumerator collectCoconut() {
        yield return new WaitForSeconds(0.4f);
        if(CoconutTree.stage3) {
            CoconutTree collect = FindObjectOfType<CoconutTree>();
            collect.OnMouseDown();
        }
    }
    IEnumerator collectCocoa() {
        yield return new WaitForSeconds(0.4f);
        if(CocoaTree.stage3) {
            CocoaTree collect = FindObjectOfType<CocoaTree>();
            collect.OnMouseDown();
        }
    }
}