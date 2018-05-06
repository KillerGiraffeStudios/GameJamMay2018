using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreeHealth : Health {



    public override void Kill() {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        this.gameObject.GetComponent<TreeSpawner>().SetDead();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "bullet(Clone)") {
            Destroy(other.gameObject);
            this.Damage();
        }
    }
}
