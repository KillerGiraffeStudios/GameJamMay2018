using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour {

    // Directional speed of the tornado
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;

    // Rotational speed of the tornado
    [SerializeField]
    private float rotation;

    // Is the player caught in the tornado
    private bool damagePlayer = false;

    // Reference to the player
    private GameObject player;



	// Use this for initialization
	void Start ()
    {
        // Generate directional speed
        //this.GameObject.getComponent<RidgidBody>();

        // Generate a rotation


	}
	
	// Update is called once per frame
	void Update ()
    {
        // Player takes damage if they are in the tornado
        if (this.damagePlayer)
        {
            this.player.SendMessage("TakeDamage", 10);
        }
    }


    /// <summary>
    /// OnCollisionEnter() will be called whenever an object collieds with the tornado and then 
    /// call the correct function.
    /// </summary>
    /// <param name="obj"></param>
    void OnCollisionEnter(Collision obj)
    {
        // If we collied with the players, refrence them and start dealing damage
        if (obj.gameObject.tag == "Ship")
        {
            this.player = obj.gameObject;
            this.damagePlayer = true;
        }
    }
}
