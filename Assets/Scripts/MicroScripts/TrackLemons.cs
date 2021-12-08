using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrackLemons : MonoBehaviour {
    public int lemon = 0;
    public Text lemonTxt, lemonTxt2;
    void Start(){
        if (PlayerPrefs.HasKey("FruitL")) lemon = PlayerPrefs.GetInt("FruitL");
    }
    void Update() {        
        lemonTxt.text = "" + lemon;
        lemonTxt2.text = "" + lemon;

        lemon += 0;
        PlayerPrefs.SetInt("FruitL", lemon);
    }
}