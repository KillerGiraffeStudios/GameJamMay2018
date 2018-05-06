using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    // Reference to the players
    [SerializeField]
    private GameObject anchor;

    // Use this for initialization
    void Start () {
        this.transform.position = new Vector3(this.anchor.transform.position.x, this.anchor.transform.position.y, 0);
    }
	
	// Update is called once per frame
	void Update () {

        // Grab the position of the players
        float anchorX = this.anchor.transform.position.x;
        float anchorY = this.anchor.transform.position.y;

        if(anchorX < 2.0f)
        {
            anchorX = 2.0f;
        }

        if (anchorX > 198.0f)
        {
            anchorX = 198.0f;
        }

        if (anchorY < 2.0f)
        {
            anchorY = 2.0f;
        }

        if (anchorY > 198.0f)
        {
            anchorY = 198.0f;
        }

        this.transform.position = new Vector3(anchorX, anchorY, 0);
	}
}
