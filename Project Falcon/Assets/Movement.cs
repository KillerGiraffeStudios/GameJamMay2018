using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Movement : MonoBehaviour {
	public GamePad.Index Player = GamePad.Index.One;
	private Rigidbody2D r_body;
	// public float acceleration = 0;
	// public float turnSpeed = 1;
	// public float maxVelocity;
	// Use this for initialization
	void Start () {
		r_body = GetComponent<Rigidbody2D>();
	}
	
	Vector2 leftStick;
	// Update is called once per frame
	void Update () {
		leftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, Player);
		// leftStick.Normalize();
		transform.Rotate(0,0,-leftStick.x * MetaScript.getTurnSpeed());
		
		float rotation = Mathf.Deg2Rad * (transform.eulerAngles.z);

		if(GamePad.GetButton(GamePad.Button.B, Player)){
			r_body.AddForce(r_body.velocity * -4);
		}else{//} if(GamePad.GetButton(GamePad.Button.A,Player)){
			r_body.AddForce(new Vector2(Mathf.Cos(rotation),Mathf.Sin(rotation)) * MetaScript.getAcceleration());
		}
		

		// Vector2 dir = leftStick * r_body.velocity;

		if(r_body.velocity.sqrMagnitude > Mathf.Pow(MetaScript.getMaxSpeed(),2)){
			r_body.velocity = r_body.velocity.normalized * MetaScript.getMaxSpeed();
		}
		// if(dir.x<0){
		// 	leftStick.y *= 2;
		// }
		// if(dir.y<0){
		// 	leftStick.x *= 2;
		// }
	}
}
