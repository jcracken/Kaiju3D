using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

    public GameObject target;
    Animator myAnimator;
    public AudioSource aud;
    public float delay = 3f;
    public int damage = 5;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Monster");
        myAnimator = GetComponent<Animator>();
        InvokeRepeating("shoot", 0.0f, delay);
        myAnimator.ResetTrigger("boom");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90.0f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 0.5f);
    }

    void shoot () {
        if(transform.position.x > -5.0f) {
            myAnimator.SetTrigger("boom");
            aud.Play(0);
            Vector3 fwd = transform.TransformDirection(Vector3.up);
            float dist = Vector3.Distance(transform.position, target.transform.position);
            if (!Physics2D.Raycast(transform.position, fwd, dist)) {
                target.GetComponent<monsterMove>().health -= damage;
            }
        }
    }
}
