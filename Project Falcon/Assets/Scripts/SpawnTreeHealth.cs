using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreeHealth : Health {

    public GameObject explosion;
    public GameObject healPick;
    public GameObject Guardian;

    void Start() {
        currentHealth = maxHealth * (GlobalValues.numPlayers/2);
    }

    public override void Kill() {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        this.gameObject.GetComponent<TreeSpawner>().SetDead();
        GlobalValues.oakTreesKilled += 1;
        if (Random.Range(1, 5) <= 2) {
            Instantiate(healPick, this.transform.position, this.transform.rotation);
        }
        for (int i = 0; i < (int)(GlobalValues.oakTreesKilled * GlobalValues.difficulty * (GlobalValues.numPlayers/4) * 0.25f); i++) {
            int rand = Mathf.FloorToInt(Random.Range(1f, 4.9f));
            if (rand == 1) {
                float randX = Random.Range(-5, 5);
                Instantiate(Guardian, new Vector3(this.transform.position.x + randX, this.transform.position.y + 8f, this.transform.position.z), Quaternion.identity);
                GlobalValues.numCreatures++;

            } else if (rand ==2){
                float randX = Random.Range(-5, 5);
                Instantiate(Guardian, new Vector3(this.transform.position.x + randX, this.transform.position.y - 8f, this.transform.position.z), Quaternion.identity);
                GlobalValues.numCreatures++;
            } else if (rand == 3) {
                float randY = Random.Range(-5, 5);
                Instantiate(Guardian, new Vector3(this.transform.position.x + 8, this.transform.position.y + randY, this.transform.position.z), Quaternion.identity);
                GlobalValues.numCreatures++;
            } else if (rand == 4) {
                float randY = Random.Range(-5, 5);
                Instantiate(Guardian, new Vector3(this.transform.position.x - 8, this.transform.position.y + randY, this.transform.position.z), Quaternion.identity);
                GlobalValues.numCreatures++;
            }
        }
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
