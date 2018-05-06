using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}

