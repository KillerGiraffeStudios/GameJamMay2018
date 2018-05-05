using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour {

    // Directional speed of the tornado
    [SerializeField]
    float speed;

    // Rotational speed of the tornado
    [SerializeField]
    float rotation;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayerTakeDamage(GameObject player)
    {
        // Send damage to player
    }
}
