using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPickup : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "anchor") {
            Health anchorHP = other.gameObject.gameObject.GetComponent<Health>();
            anchorHP.currentHealth = anchorHP.currentHealth + anchorHP.maxHealth;
            destroy(gameObject);
        }
    }
}
