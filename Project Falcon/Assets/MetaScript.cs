using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaScript : MonoBehaviour {
	private static GameObject Meta;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static GameObject GetMeta(){
		if(Meta == null)
			Meta = GameObject.Find("Meta");
		return Meta;
	}
	public static MetaScript GetMetaScript(){
		return GetMeta().GetComponent<MetaScript>();
	}
	
	// TEMP
	public float maxSpeed = 2.8f;
	public static float getMaxSpeed(){
		return GetMetaScript().maxSpeed;
	}

	public float acceleration = 1.5f;
	public static float getAcceleration(){
		return GetMetaScript().acceleration;
	}

	public float turnSpeed = 1f;
	public static float getTurnSpeed(){
		return GetMetaScript().turnSpeed;
	}
}
