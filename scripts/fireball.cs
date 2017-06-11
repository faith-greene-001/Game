using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
    public float speed = 7.0f;
    public int damage = 1;
	// Use this for initialization
	void OnTriggerEnter (Collider other) {
        playerchara player = other.GetComponent<playerchara>();
        if (player!= null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
