using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatEvents : MonoBehaviour {

	// int squirrel,rabbit,cat,bear = 0;
	Dictionary<string, int> killCount;
	public AudioClip [] killEvent;
	public AudioClip startAudio;
	AudioSource source;
	const string total = "total";

	// Use this for initialization
	void Start () {
		killCount = new Dictionary<string, int>();
		killCount.Add(total,0);
		source = GetComponent<AudioSource>();
		source.clip = startAudio;
		source.Play();
	}
	
	public void addKill(string key){
		if(killCount.ContainsKey(key)){
			killCount[key] ++;
		}else{
			killCount.Add(key,1);
		}
		killCount[total]++;

		if(killCount[total] == 1){
			source.clip = killEvent[0];
			source.Play();
		}else
		if(killCount[total]%30==0){
			source.clip = killEvent[Random.Range(1,killEvent.Length)];
			source.Play();
		}

	}
}
