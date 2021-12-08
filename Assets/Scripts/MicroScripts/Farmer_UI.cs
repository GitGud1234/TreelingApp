using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Farmer_UI : MonoBehaviour {
    public BoxCollider2D[] island_col;
    public GameObject[] actives;
    public GameObject ui_element;
    public GameObject Tasks, Shop, Farmers, Industry, Inventory, Help, Store;  
    public static bool uiHidden = true;

    void SetInActive() {
        for(int i = 0; i < island_col.Length; i++) {
            island_col[i].enabled = false;
        }
        for(int i = 0; i < actives.Length; i++) {
            actives[i].transform.localPosition = new Vector3 (-500,380,0);
        }
    }
    void SetActive() {
        for(int i = 0; i < island_col.Length; i++) {
            island_col[i].enabled = true;
        }
        for(int i = 0; i < actives.Length; i++) {
            actives[0].transform.localPosition = new Vector3 (-324,380,0);
            actives[1].transform.localPosition = new Vector3 (-324,240,0);
            actives[2].transform.localPosition = new Vector3 (-324,100,0);
            actives[3].transform.localPosition = new Vector3 (-324,-40,0);
            actives[4].transform.localPosition = new Vector3 (-324,-180,0);
        }
    }
    public void OnMouseDown() {
        uiHidden = !uiHidden;
        if(uiHidden) {
            show();
            SetActive();
            ui_element.transform.localPosition = new Vector3(0,2500,0);
        } else {
            hide();
            SetInActive();
            ui_element.transform.localPosition = new Vector3(0,0,0);
        }
    }
    void hide() {
        Tasks.transform.localPosition = new Vector3 (500,400,0);
        Shop.transform.localPosition = new Vector3 (500,220,0);
        //Farmers.transform.localPosition = new Vector3 (500,40,0);
        Industry.transform.localPosition = new Vector3 (500,-140,0);
        Inventory.transform.localPosition = new Vector3 (500,580,0);
        Help.transform.localPosition = new Vector3 (500,-500,0);
        Store.transform.localPosition = new Vector3(800,600,0);
    }
    void show() {
        Tasks.transform.localPosition = new Vector3(280,400,0);
        Shop.transform.localPosition = new Vector3(280,220,0);
        Farmers.transform.localPosition = new Vector3(280,40,0);
        Industry.transform.localPosition = new Vector3(280,-140,0);
        Inventory.transform.localPosition = new Vector3 (-280,580,0);
        Help.transform.localPosition = new Vector3 (280,-500,0);
        Store.transform.localPosition = new Vector3(300,600,0);
    }    
}