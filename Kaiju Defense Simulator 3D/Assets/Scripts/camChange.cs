using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(224.0f, 579.0f, 215.0f);
        transform.rotation = Quaternion.Euler(90.0f, -90.0f, 0.0f);
	}

    // Update is called once per frame
    public void change() {
        transform.position = new Vector3(513.0f, 161.0f, 190.0f);
        transform.rotation = Quaternion.Euler(28.537f, -70.388f, -1.293f);
    }
}
