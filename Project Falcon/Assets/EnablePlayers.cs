﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayers : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for(int i=1;i<5;i++){
			if(i > GlobalValues.numPlayers){//MetaScript.GetMetaScript().playerCount){
				GameObject.Find("Chain"+i).SetActive(false);
				GameObject.Find("EnergyBar"+i).SetActive(false);
			}
		}
	}
}
