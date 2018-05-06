using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaScript : MonoBehaviour {
	private static GameObject Meta;
	private static GameObject Anchor;
	private static StatEvents stat;

	
	[Range(1,4)]public int playerCount = 1;
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
	public static GameObject GetAnchor(){
		if(Anchor == null){
			Anchor = GameObject.Find("anchor");
		}
		return Anchor;
	}
	public static StatEvents GetStat(){
		if(stat == null){
			stat = GetMeta().GetComponent<StatEvents>();
		}
		return stat;
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
