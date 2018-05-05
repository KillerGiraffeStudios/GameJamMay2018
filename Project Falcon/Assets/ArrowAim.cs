using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAim : MonoBehaviour {


    public GameObject target;
    public GameObject playerCore;
    private int updateCounter;
    // Use this for initialization
    void Start() {
        updateCounter = 0;
        FindNearestTree();

    }

    // Update is called once per frame
    void Update() {
        updateCounter++;
        if (updateCounter >= 30) {
            FindNearestTree();
        }
        if (target != null) {
            this.transform.LookAt(target.transform.position, Vector3.up);
            this.transform.position = playerCore.transform.position;
            this.transform.position = this.transform.position + this.transform.forward * 3;
            this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

            Vector3 moveDirection = gameObject.transform.position - target.transform.position;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else {
            Destroy(this.gameObject);
        }
    }

    void FindNearestTree() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("SpawnTree");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        updateCounter = 0;
        target = closest;
    }
}
