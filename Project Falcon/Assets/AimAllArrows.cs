using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAllArrows : MonoBehaviour {

    public GameObject arrow;
	// Use this for initialization
	void Start () {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("SpawnTree");
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            GameObject newArrow = Instantiate(arrow);
            newArrow.GetComponent<ArrowAim>().target = go;
            newArrow.GetComponent<ArrowAim>().playerCore = this.gameObject;
        }
    }
}
