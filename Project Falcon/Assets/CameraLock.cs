using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour {
	public GameObject lockObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = lockObject.transform.position;
		pos.z = -10;
		transform.position = pos;

	}
}
