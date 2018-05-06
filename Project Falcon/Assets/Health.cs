using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public BarScript UI = null;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}

    void Damage()
    {
        currentHealth--;
        if(UI != null){
            UI.setBar(currentHealth*1f/maxHealth);
        }
        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        if(CompareTag("enemy")){
            MetaScript.GetStat().addKill(tag);
        }
        Destroy(gameObject);
    }
}

