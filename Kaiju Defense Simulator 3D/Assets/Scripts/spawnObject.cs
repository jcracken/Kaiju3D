using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// modified from source code provided by TheFlyingKeyboard
// licensed under MIT license, © 2017 TheFlyingKeyboard
// theflyingkeyboard.net
public class spawnObject : MonoBehaviour {
    public GameObject artillery;
    public GameObject infantry;
    public GameObject tank;
    public int type = 0;
    public int resources = 5000;
    public Text resText;
    // Use this for initialization
    void Start () {
        int width = 800; // or something else
        int height = 900; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }
	
	// Update is called once per frame
	void Update () {
        resText.text = resources.ToString();
        if (Input.GetMouseButtonDown(0)) {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            if (spawnPosition.y < -3.5 || spawnPosition.y > 4.5) return;
            switch (type) {
                case 0:
                    //do nothing
                    break;
                case 1:
                    if(resources >= 50) {
                        GameObject inf = Instantiate(infantry, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                        resources -= 50;
                    }
                    break;
                case 2:
                    if(resources >= 100) {
                        GameObject tan = Instantiate(tank, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                        resources -= 100;
                    }
                    break;
                case 3:
                    if(resources >= 200) {
                        GameObject art = Instantiate(artillery, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                        resources -= 200;
                    }
                    break;
            }
        }
    }
    public void changeType(int t) {
        type = t;
    }
}
