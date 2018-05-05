using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAim : MonoBehaviour {


    public GameObject target;
    public GameObject playerCore;
    public float distance;

    // Update is called once per frame
    void Update() {
        if (target != null) {
            this.transform.LookAt(target.transform.position, Vector3.up);
            this.transform.position = playerCore.transform.position;
            this.transform.position = this.transform.position + this.transform.forward * 4;
            this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

            Vector3 moveDirection = gameObject.transform.position - target.transform.position;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            distance = Vector3.Distance(this.transform.position, target.transform.position);
            this.transform.localScale = new Vector3((0.05f + (0.95f*(5/distance))), (0.05f + (0.95f * (5 / distance))), (0.05f + 0.95f * (5 / distance)) );
        }
        if ( distance < 5) {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        } else {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
       
    }
}
