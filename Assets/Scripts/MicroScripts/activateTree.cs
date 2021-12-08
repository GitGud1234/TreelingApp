using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activateTree : MonoBehaviour {
    public GameObject appleTree,bananaTree,orangeTree,lemonTree,coconutTree,cocoaTree;
    public static bool activateAppleTree;
    public static bool activateBananaTree;
    public static bool activateOrangeTree;
    public static bool activateLemonTree;
    public static bool activateCoconutTree;
    public static bool activateCocoaTree;

    public void apple() {
        if (activateAppleTree) appleTree.SetActive(true);
    }
    public void banana() {
        if (activateBananaTree) bananaTree.SetActive(true);
    }
    public void orange() {
        if (activateOrangeTree) orangeTree.SetActive(true);
    }
    public void lemon() {
        if (activateLemonTree) lemonTree.SetActive(true);
    }
    public void coconut() {
        if(activateCoconutTree) coconutTree.SetActive(true);
    }
    public void cocoa() {
        if(activateCocoaTree) cocoaTree.SetActive(true);
    }
}