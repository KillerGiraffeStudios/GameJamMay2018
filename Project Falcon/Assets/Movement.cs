using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Movement : MonoBehaviour {
	public GamePad.Index Player = GamePad.Index.One;
	private Rigidbody2D r_body;
	private Abilities abilities;
    public Sprite boostSprite;
    public Sprite normalSprite;
    public Sprite brakeSprite;
    // public float acceleration = 0;
    // public float turnSpeed = 1;
    // public float maxVelocity;
    // Use this for initialization

    void Start () {
		r_body = GetComponent<Rigidbody2D>();
		abilities = GetComponent<Abilities>();
        

    }
	
	Vector2 leftStick;
	Vector2 rightStick;
	// Update is called once per frame
	void Update () {
		leftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, Player);
		// rightStick = GamePad.GetAxis(GamePad.Axis.RightStick, Player);
		// leftStick += rightStick;
		leftStick += GamePad.GetAxis(GamePad.Axis.Dpad, Player);
		//Switch controller
		// leftStick += new Vector2(GamePad.GetTrigger(GamePad.Trigger.LeftTrigger, Player),0);
		// leftStick.Normalize();
		transform.Rotate(0,0,-leftStick.x * MetaScript.getTurnSpeed());
		
		float rotation = Mathf.Deg2Rad * (transform.eulerAngles.z);



		float boost = 1f;
        if (abilities.boost(Player))
        {
            boost = 5f;
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = boostSprite;
        }
        else if (abilities.brake(Player, r_body))
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = brakeSprite;

        }
        else {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = normalSprite;

            abilities.addEnergy();
        }
        {
            
           
        }

		abilities.updateUI();



		r_body.AddForce(new Vector2(Mathf.Cos(rotation),Mathf.Sin(rotation)) * MetaScript.getAcceleration() * boost);
		

		// Enforce Speed Limit
		if(r_body.velocity.sqrMagnitude > Mathf.Pow(MetaScript.getMaxSpeed(),2)){
			r_body.velocity = r_body.velocity.normalized * MetaScript.getMaxSpeed();
		}
	}
}
