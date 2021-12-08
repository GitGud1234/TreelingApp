using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour {
    public GameObject islandObject1,islandObject2,islandObject3,islandObject4,islandObject5,islandObject6;
    public GameObject AppleUi,BananaUi,OrangeUi,LemonUi,CoconutUi,CocoaUi;
    //total of 6 islands 0>1>2>3>4>5
    private int currentIsland = 0;
 
    void Update() {
       if(currentIsland != 0) AppleUi.SetActive(false);
       else AppleUi.SetActive(true);

       if(currentIsland != 1) BananaUi.SetActive(false);
       else BananaUi.SetActive(true);

       if(currentIsland != 2) OrangeUi.SetActive(false);
       else OrangeUi.SetActive(true);

       if(currentIsland != 3) LemonUi.SetActive(false);
       else LemonUi.SetActive(true);   

       if(currentIsland != 4) CoconutUi.SetActive(false);
       else CoconutUi.SetActive(true);   

       if(currentIsland != 5) CocoaUi.SetActive(false);
       else CocoaUi.SetActive(true);          
       
       Swipe();
    }

    void Swipe() {
        //starting island1 -> island2 -> island3
        if(NextIsland.swipeLeft) {
            //print("swipe right" + currentIsland);
            currentIsland++;
            if(currentIsland == 6)
            currentIsland = 5;
        }
        if(NextIsland.swipeRight) {
            //print("swipe left" + currentIsland);
            currentIsland--;
            if(currentIsland == -1)
            currentIsland = 0;
        }
        if(currentIsland == 0) {
            islandObject1.transform.localPosition = new Vector3(-262,-618,0);
            islandObject2.transform.localPosition = new Vector3(500,-618,0);
            islandObject3.transform.localPosition = new Vector3(800,-618,0);
            islandObject4.transform.localPosition = new Vector3(1200,-618,0);
            islandObject5.transform.localPosition = new Vector3(1600,-618,0);
            islandObject6.transform.localPosition = new Vector3(2000,-618,0);
        } 
        if(currentIsland == 1){
            islandObject2.transform.localPosition = new Vector3(-262,-618,0); 
            islandObject1.transform.localPosition = new Vector3(-1000,-618,0);
            islandObject3.transform.localPosition = new Vector3(500,-618,0);
            islandObject4.transform.localPosition = new Vector3(800,-618,0);
            islandObject5.transform.localPosition = new Vector3(1200,-618,0);
            islandObject6.transform.localPosition = new Vector3(1600,-618,0);
        }
        if(currentIsland == 2){
           
            islandObject3.transform.localPosition = new Vector3(-262,-618,0);
            islandObject1.transform.localPosition = new Vector3(-1300,-618,0);
            islandObject2.transform.localPosition = new Vector3(-1000,-618,0);
            islandObject4.transform.localPosition = new Vector3(500,-618,0);
            islandObject5.transform.localPosition = new Vector3(800,-618,0);
            islandObject6.transform.localPosition = new Vector3(1200,-618,0);
        }
        if(currentIsland == 3){
            
            islandObject1.transform.localPosition = new Vector3(-1600,-618,0);
            islandObject2.transform.localPosition = new Vector3(-1300,-618,0);
            islandObject3.transform.localPosition = new Vector3(-1000,-618,0);
            islandObject4.transform.localPosition = new Vector3(-262,-618,0);
            islandObject5.transform.localPosition = new Vector3(500,-618,0);
            islandObject6.transform.localPosition = new Vector3(800,-618,0);
        }
        if(currentIsland == 4){
            islandObject1.transform.localPosition = new Vector3(-1900,-618,0);
            islandObject2.transform.localPosition = new Vector3(-1600,-618,0);
            islandObject3.transform.localPosition = new Vector3(-1300,-618,0);
            islandObject4.transform.localPosition = new Vector3(-1000,-618,0);
            islandObject5.transform.localPosition = new Vector3(-262,-618,0);
            islandObject6.transform.localPosition = new Vector3(500,-618,0);
        }
        if(currentIsland == 5){
            islandObject1.transform.localPosition = new Vector3(-2200,-618,0);
            islandObject2.transform.localPosition = new Vector3(-1900,-618,0);
            islandObject3.transform.localPosition = new Vector3(-1600,-618,0);
            islandObject4.transform.localPosition = new Vector3(-1300,-618,0);
            islandObject5.transform.localPosition = new Vector3(-1000,-618,0);
            islandObject6.transform.localPosition = new Vector3(-262,-618,0);
        }
    }
}