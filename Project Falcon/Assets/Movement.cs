using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Movement : MonoBehaviour {
	public GamePad.Index Player = GamePad.Index.One;
	private Rigidbody2D r_body;
	public float acceleration;
	public float maxVelocity;
	private float maxSqrVelocity;
	// Use this for initialization
	void Start () {
		r_body = GetComponent<Rigidbody2D>();
		maxSqrVelocity = maxVelocity * maxVelocity;
	}
	
	Vector2 leftStick;
	// Update is called once per frame
	void Update () {
		leftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, Player);
		// leftStick.Normalize();
		transform.Rotate(0,0,-leftStick.x);
		
		float rotation = Mathf.Deg2Rad * (transform.eulerAngles.z);
		r_body.AddForce(new Vector2(Mathf.Cos(rotation),Mathf.Sin(rotation)));


		// Vector2 dir = leftStick * r_body.velocity;

		// if(r_body.velocity.sqrMagnitude> maxSqrVelocity){
		// 	r_body.velocity = r_body.velocity.normalized * maxVelocity;
		// }
		// if(dir.x<0){
		// 	leftStick.y *= 2;
		// }
		// if(dir.y<0){
		// 	leftStick.x *= 2;
		// }
	}
}
