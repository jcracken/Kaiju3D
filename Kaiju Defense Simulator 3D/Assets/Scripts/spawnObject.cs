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
        int width = 1920; // or something else
        int height = 1080; // or something else
        bool isFullScreen = true; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }
	
	// Update is called once per frame
	void Update () {
        resText.text = resources.ToString();
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            if(Physics.Raycast(ray, out hit)) {
                Vector3 spawnPosition = hit.point;
                if (spawnPosition.x < 0.0f || spawnPosition.x > 500.0f || spawnPosition.z > 500.0f || spawnPosition.z < 0.0f || spawnPosition.y < 0.0f || spawnPosition.y > 1.0f) return;
                switch (type) {
                    case 0:
                        //do nothing
                        break;
                    case 1:
                        if (resources >= 50) {
                            GameObject inf = Instantiate(infantry, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                            resources -= 50;
                        }
                        break;
                    case 2:
                        if (resources >= 100) {
                            GameObject tan = Instantiate(tank, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                            resources -= 100;
                        }
                        break;
                    case 3:
                        if (resources >= 200) {
                            GameObject art = Instantiate(artillery, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                            resources -= 200;
                        }
                        break;
                }
            }
        }
    }
    public void changeType(int t) {
        type = t;
    }
}
