using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "enemy")
        {
            coll.gameObject.SendMessage("Damage");
            GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(newExplosion, 1f);
            Destroy(gameObject);
        }
    }
}
