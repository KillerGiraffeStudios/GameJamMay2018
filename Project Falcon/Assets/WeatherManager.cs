using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour {

    // Reference to partical system
    private ParticleSystem particalSystem;

    // Reference to the Tornado prefab
    [SerializeField]
    private GameObject tornadoPrefab;


	// Use this for initialization
	void Start () {
		this.particalSystem = GetComponent<ParticleSystem>();
        this.SpawnTornado();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    /// <summary>
    /// Start rainning
    /// </summary>
    void StartRain()
    {
        var emission = this.particalSystem.emission;
        emission.enabled = true;
    }


    /// <summary>
    /// Stop rainning
    /// </summary>
    void StopRain()
    {
        var emission = this.particalSystem.emission;
        emission.enabled = false;
    }


    /// <summary>
    /// SpawnTornado() will create a tornado
    /// </summary>
    void SpawnTornado()
    {
        // Determine the starting wall position where 1 = top and go clockwise
        int wall = Random.Range(0, 4);

        int positionX = 0;
        int positionY = 0;

        if (wall == 1)
        {
            positionX = Random.Range(-101, 100);
            positionY = 100;
        }
        else if (wall == 2)
        {
            positionY = Random.Range(-101, 100);
            positionX = 100;
        }
        else if (wall == 3)
        {
            positionX = Random.Range(-101, 100);
            positionY = -100;
        }
        else
        {
            positionY = Random.Range(-101, 100);
            positionX = -100;
        }

        // Instantiate tornado
        GameObject newTornado = Instantiate(this.tornadoPrefab, new Vector3(positionX, positionY, 0));
    }
}
