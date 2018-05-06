using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Damage()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
    }
}

