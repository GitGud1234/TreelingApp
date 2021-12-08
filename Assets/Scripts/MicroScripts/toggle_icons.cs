using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle_icons : MonoBehaviour {
    public GameObject Tasks, Shop, Farmers, Industry;
    public BoxCollider2D ToggleIconsCollider;
    bool onscreen = false;
   
    void OnMouseDown() {
        onscreen = !onscreen;
        show();
    }
    void show() {
        if(onscreen) {
            Tasks.transform.localPosition = new Vector3(280,400,0);
            Shop.transform.localPosition = new Vector3(280,220,0);
            Farmers.transform.localPosition = new Vector3(280,40,0);
            Industry.transform.localPosition = new Vector3(280,-140,0);
        }
        else {
            Tasks.transform.localPosition = new Vector3 (500,400,0);
            Shop.transform.localPosition = new Vector3 (500,220,0);
            Farmers.transform.localPosition = new Vector3 (500,40,0);
            Industry.transform.localPosition = new Vector3 (500,-140,0);
        }
    }
}