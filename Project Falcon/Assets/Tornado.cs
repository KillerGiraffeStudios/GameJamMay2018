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

    // Force of the tornado
    [SerializeField]
    private float force;

    // Is the player caught in the tornado
    // private bool damagePlayer = false;

    // Reference to the player
    private GameObject player;



	// Use this for initialization
	void Start ()
    {


    }
	
	// Update is called once per frame
	void Update ()
    {
        // Check if tornado needs to be deleted
        CheckDespawnLocation();

        // Move tornado
        TornadoMovement();

        // Player takes damage if they are in the tornado
        /*
        if (this.damagePlayer)
        {
            this.player.SendMessage("Damage");
        }*/


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
    /// Will check if the tornado is out of range and needs to despawn
    /// </summary>
    void CheckDespawnLocation()
    {
        if(this.gameObject.transform.position.x < - 110.0f || this.gameObject.transform.position.x > 110.0f ||
            this.gameObject.transform.position.y < -110.0f || this.gameObject.transform.position.y > 110.0f)
        {
            Destroy(this.gameObject, 5.0f);
        }
    }


    /// <summary>
    /// Pull in an object
    /// </summary>
    /// <param name="unfortunateSoul"></param>
    void TornadoForce(GameObject unfortunateSoul)
    {
        // Get X distance
        float xDistance = unfortunateSoul.transform.position.x - this.gameObject.transform.position.x;

        // Get Y distance
        float yDistance = unfortunateSoul.transform.position.y - this.gameObject.transform.position.y;

        // Pull towards tornado
        unfortunateSoul.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.force * (1 / Mathf.Max(xDistance,minDistance)), this.force * (1 / Mathf.Max(yDistance,minDistance))));
        print("Tornado force applied.");
    }
    float minDistance = 0.1f;
    
    /// <summary>
    /// Throw anything in the tornado!
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        print("Trigger stay activated");
        if(collision.gameObject.tag == "Player"  || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "anchor")
        {
            TornadoForce(collision.gameObject);
        }
    }

}
