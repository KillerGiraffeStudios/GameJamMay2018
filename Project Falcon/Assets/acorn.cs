using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acorn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "anchor")
        {
            coll.gameObject.SendMessage("Damage");
            Destroy(this.gameObject);
        }
    }
}
