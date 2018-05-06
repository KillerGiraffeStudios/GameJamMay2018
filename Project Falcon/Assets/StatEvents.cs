using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatEvents : MonoBehaviour {

	// int squirrel,rabbit,cat,bear = 0;
	Dictionary<string, int> killCount;
	public AudioClip [] killEvent;
	AudioSource source;

	// Use this for initialization
	void Start () {
		killCount = new Dictionary<string, int>();
		killCount.Add("total",0);
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			addKill("lolz");
		}
	}
	public void addKill(string key){
		if(killCount.ContainsKey(key)){
			killCount[key] ++;
		}else{
			killCount.Add(key,1);
		}
		killCount["total"]++;

		bool play = true;
		switch(killCount["total"]){
			// case 1:
			// 	source.clip = killEvent[0];
			// 	break;
			default:
				play = false;
				break;
		}

		if(play){
			source.Play();
		}

	}
}
