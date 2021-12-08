using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour {
    public GameObject Apple, Banana, Orange, Lemon, Coconut, Cocoa;
    public static int apple, banana, orange, lemon, coconut, cocoa;

    void Start() {
        //Debug.Log(Application.persistentDataPath);

        apple = PlayerPrefs.GetInt("Apple", 1);
        banana = PlayerPrefs.GetInt("Banana", 0);
        orange = PlayerPrefs.GetInt("Orange", 0);
        lemon = PlayerPrefs.GetInt("Lemon", 0);
        coconut = PlayerPrefs.GetInt("Coconut", 0);
        cocoa = PlayerPrefs.GetInt("Cocoa", 0);
    }
    
    void Update() {
        activeItems();
        activeTrees();
    }
    void activeItems() {
        //item actives
    }

    void activeTrees() {
        if(apple == 0) Apple.SetActive(false);
        if(apple == 1) Apple.SetActive(true);
        
        if (banana == 0) Banana.SetActive(false);
        if (banana == 1) Banana.SetActive(true);
        
        if (orange == 0) Orange.SetActive(false);
        if (orange == 1) Orange.SetActive(true);
        
        if (lemon == 0) Lemon.SetActive(false);
        if (lemon == 1) Lemon.SetActive(true);
        
        if (coconut == 0) Coconut.SetActive(false);
        if (coconut == 1) Coconut.SetActive(true);
        
        if (cocoa == 0) Cocoa.SetActive(false);
        if (cocoa == 1) Cocoa.SetActive(true);
    }
}