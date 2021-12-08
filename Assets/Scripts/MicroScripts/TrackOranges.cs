using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrackOranges : MonoBehaviour {
    public int orange = 0;
    public Text orangeTxt,orangeTxt2;
    void Start() {
        if (PlayerPrefs.HasKey("FruitO")) orange = PlayerPrefs.GetInt("FruitO");
    }
    void Update() {
        orangeTxt.text = "" + orange;
        orangeTxt2.text = "" + orange;

        orange += 0;
        PlayerPrefs.SetInt("FruitO", orange);
    }
}