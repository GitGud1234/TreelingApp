using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackCocoa : MonoBehaviour {
    public int cocoa = 0;
    public Text cocoaTxt, cocoaTxt2;
    void Start() {
        if (PlayerPrefs.HasKey("FruitC")) cocoa = PlayerPrefs.GetInt("FruitC");
    }
    void Update() {
        cocoaTxt.text = "" + cocoa;
        cocoaTxt2.text = "" + cocoa;

        cocoa += 0;
        PlayerPrefs.SetInt("FruitC", cocoa);
    }
}