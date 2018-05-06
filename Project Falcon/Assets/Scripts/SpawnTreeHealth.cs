using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreeHealth : Health {



    public override void Kill() {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        this.gameObject.GetComponent<TreeSpawner>().isdead = true;
    }
    void OnTriggerEnter(Collider other) {
        if(other.name == "bullet") {
            Destroy(other.gameObject);
            this.Damage();
        }
    }
}
