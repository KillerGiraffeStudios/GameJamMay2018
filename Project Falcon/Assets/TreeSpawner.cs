﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeSpawner : MonoBehaviour {

    public GameObject[] enemyList;
    public int[] spawnRate;
    public int[] spawnsAtTreesDead;
    private float[] numEnemiesSpawned;
    public int treesDead = 0;
    public GameObject[] trees;
    public bool isdead = false;
    private float tick = 0;
    private int spawnRateMulti = 0;

    // Use this for initialization
    void Start () {
		trees = GameObject.FindGameObjectsWithTag("SpawnTree");
        numEnemiesSpawned = new float[enemyList.Length];
        for (int i = 0; i < numEnemiesSpawned.Length; i++ ) {
            numEnemiesSpawned[i] = 0;
        }

        if (GlobalValues.numPlayers == 0) {
            spawnRateMulti = 1;
        } else {
            spawnRateMulti = GlobalValues.numPlayers;
        }
    }

    private void FixedUpdate() {
        tick++;
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
        /*
         *For each enemy check to see if the correct number of trees have died to spawn them and then check 
         * to see if the correct number of ticks have passed to spawn the creature
         */
        for(int i = 0; i < enemyList.Length; i = i + 1) {
            if (spawnsAtTreesDead[i] <= treesDead && !isdead) {
                if (Mathf.Floor(tick/(spawnRate[i]/spawnRateMulti)) > numEnemiesSpawned[i]) {
                    Spawn(enemyList[i]);
                    numEnemiesSpawned[i] = numEnemiesSpawned[i] + 1;
                }
            }
        }
		
	}
    public void SetDead() {
        isdead = true;
        int newTreesDead = 0;
        foreach (GameObject tree in trees) {

            if ((tree.GetComponent<TreeSpawner>().isdead)) {
                newTreesDead++;
            }
        }
        if (newTreesDead >= trees.Length) {
            SceneManager.LoadScene("WinScene");
        }
    }

    void Spawn(GameObject enemy) {
        float randY = Random.Range(-10, 10);
        float randX = Random.Range(-10, 10);
        if(GlobalValues.numCreatures < 350) {
            Instantiate(enemy, new Vector3(this.transform.position.x + randX, this.transform.position.y + randY, this.transform.position.z), Quaternion.identity);
            GlobalValues.numCreatures++;
        }
    }
}
