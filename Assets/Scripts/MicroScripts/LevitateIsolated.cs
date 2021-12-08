using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitateIsolated : MonoBehaviour {
    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();
   
    public float amplitude = 0.5f;
    public float frequency = 0.5f;
    void Start() {
        posOffset = transform.position;
    }
    void Update() {
       tempPos = posOffset;
       tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
       tempPos.x = transform.position.x;
        
       transform.position = tempPos;
    }
}