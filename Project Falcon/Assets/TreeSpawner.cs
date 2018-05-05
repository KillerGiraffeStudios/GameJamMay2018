﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

    public GameObject[] enemyList;
    public int[] spawnRate;
    public int[] spawnsAtTreesDead;
    private float[] numEnemiesSpawned;
    public int treesDead = 0;
    public GameObject[] trees;
    public bool isdead = false;
    private float tick = 0;

    // Use this for initialization
    void Start () {
		trees = GameObject.FindGameObjectsWithTag("SpawnTree");
        numEnemiesSpawned = new float[enemyList.Length];
        for (int i = 0; i < numEnemiesSpawned.Length; i++ ) {
            numEnemiesSpawned[i] = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {
        int newTreesDead = 0;
        //check how many trees are dead
        foreach(GameObject tree in trees) {
            
            if ((tree.GetComponent<TreeSpawner>().isdead)) {
                newTreesDead++;
            }
        }
        treesDead = newTreesDead;
        tick++;
        /*
         *For each enemy check to see if the correct number of trees have died to spawn them and then check 
         * to see if the correct number of ticks have passed to spawn the creature
         */
        for(int i = 0; i < enemyList.Length; i = i + 1) {
            if (spawnsAtTreesDead[i] <= treesDead) {
                Debug.Log("tick: " + tick);
                if (Mathf.Floor(tick/spawnRate[i]) > numEnemiesSpawned[i]) {
                    Spawn(enemyList[i]);
                    numEnemiesSpawned[i] = numEnemiesSpawned[i] + 1;
                }
            }
        }
		
	}

    void Spawn(GameObject enemy) {
        Instantiate(enemy);
    }
}
