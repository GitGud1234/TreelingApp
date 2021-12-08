using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrackCoconuts : MonoBehaviour {
    public int coconut = 0;
    public Text coconutTxt, coconutTxt2;
    void Start() {
        if (PlayerPrefs.HasKey("FruitD")) coconut = PlayerPrefs.GetInt("FruitD");
    }
    void Update() {
        coconutTxt.text = "" + coconut;
        coconutTxt2.text = "" + coconut;

        coconut += 0;
        PlayerPrefs.SetInt("FruitD", coconut);
    }
}