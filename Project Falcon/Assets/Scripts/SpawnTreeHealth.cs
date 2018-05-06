using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreeHealth : Health {

    public GameObject explosion;

    public override void Kill() {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        this.gameObject.GetComponent<TreeSpawner>().SetDead();
        GlobalValues.oakTreesKilled += 1;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "bullet(Clone)") {
            GameObject newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion, 1f);
            Destroy(other.gameObject);
            this.Damage();
        }
    }
}
