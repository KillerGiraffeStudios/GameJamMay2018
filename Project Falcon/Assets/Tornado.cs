using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour {

    // Directional speed of the tornado
    [SerializeField]
    private float directionSpeedX;
    [SerializeField]
    private float directionSpeedY;


    // Rotational speed of the tornado
    [SerializeField]
    private float rotationSpeed;

    // Is the player caught in the tornado
    private bool damagePlayer = false;

    // Reference to the player
    private GameObject player;



	// Use this for initialization
	void Start ()
    {


    }
	
	// Update is called once per frame
	void Update ()
    {
        // Move tornado
        TornadoMovement();

        // Player takes damage if they are in the tornado
        if (this.damagePlayer)
        {
            this.player.SendMessage("TakeDamage", 1);
        }
    }


    /// <summary>
    /// Sets the speed of the tornado in the x and y directions
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetDirectionalSpeeds(float x, float y)
    {
        this.directionSpeedX = x;
        this.directionSpeedY = y;
    }


    /// <summary>
    /// TornadoMovement() is responsable for moving the tornado in a direction with its given
    /// speed and rotation.
    /// </summary>
    void TornadoMovement()
    {
        // Generate directional speed
        this.transform.Translate(new Vector3(this.directionSpeedX, this.directionSpeedY, 0) * Time.deltaTime, Space.World);

        // Generate a rotation
        this.transform.Rotate(new Vector3(0, 0, 1), this.rotationSpeed * Time.deltaTime);
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
