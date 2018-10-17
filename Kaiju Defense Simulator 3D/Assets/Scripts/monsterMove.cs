using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterMove : MonoBehaviour {
    bool one = false;
    bool two = false;
    bool three = false;

    public int health = 100;
    public Text hText;
    public Text gOver;
    public Text youWin;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        hText.text = health.ToString();
        if (health <= 0) {
            youWin.text = "You Win!";
            health = 0;
        } else {
            if (!one) {
                if (transform.position.x >= 1.3) one = true;
                else transform.Translate(0.25f * Time.deltaTime, 0, 0);
            } else if (!two) {
                if (transform.position.x < -0.6) two = true;
                else transform.Translate(-0.25f * Time.deltaTime, 0, 0);
            } else if (!three) {
                if (transform.position.y < -3.4) three = true;
                else transform.Translate(0, -0.25f * Time.deltaTime, 0);
            } else {
                transform.position = new Vector3(-0.068f, -3.462f, 0.0f);
                gOver.text = "Game Over";
                health = 10000;
            }
        }
	}
}
