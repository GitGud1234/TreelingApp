using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackApples : MonoBehaviour {
    public int apple = 0;
    public Text appleTxt, appleTxt2;
    void Start() {
        if (PlayerPrefs.HasKey("FruitA")) apple = PlayerPrefs.GetInt("FruitA");
    }
    void Update() {      
        appleTxt.text = "" + apple;
        appleTxt2.text = "" + apple;

        apple += 0;
        PlayerPrefs.SetInt("FruitA", apple);
    }
}