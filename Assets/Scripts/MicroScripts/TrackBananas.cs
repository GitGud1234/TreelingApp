using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackBananas : MonoBehaviour {
    public int banana = 0;
    public Text bananaTxt, bananaTxt2;
    void Start() {
        if (PlayerPrefs.HasKey("BTrack")) banana = PlayerPrefs.GetInt("BTrack");
    }
    void Update() {
        bananaTxt.text = "" + banana;
        bananaTxt2.text = "" + banana;

        banana += 0;
        PlayerPrefs.SetInt("BTrack", banana);
    }
}