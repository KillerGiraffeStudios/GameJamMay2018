using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAllArrows : MonoBehaviour {

    public GameObject arrow;
    public GameObject[] gos;
    public GameObject[] arrows;
    public bool notSpawned = true;
	// Use this for initialization
	void Update () {
        if (notSpawned) {
            gos = GameObject.FindGameObjectsWithTag("SpawnTree");
            if (gos.Length > 0) {
                arrows = new GameObject[gos.Length];
                Vector3 position = transform.position;
                int i = 0;
                foreach (GameObject go in gos) {
                    GameObject newArrow = Instantiate(arrow);
                    newArrow.GetComponent<ArrowAim>().target = go;
                    newArrow.GetComponent<ArrowAim>().playerCore = this.gameObject;
                    arrows[i] = newArrow;
                    i++;
                }
                notSpawned = false;
            }
        }
    }
}
