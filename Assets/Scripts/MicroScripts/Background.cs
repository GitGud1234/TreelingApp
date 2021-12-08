using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    private float BackgroundSpeed = 0.03f;
    [SerializeField]
    private Renderer bgRend;

    void Update() {
        bgRend.material.mainTextureOffset += new Vector2(BackgroundSpeed * Time.deltaTime, 0f);
    }
}