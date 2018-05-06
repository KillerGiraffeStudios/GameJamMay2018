using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    // Reference to the players
    [SerializeField]
    private GameObject anchor;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(anchor.position.transform.x, anchor.position.transform.y, 0);
	}
}
