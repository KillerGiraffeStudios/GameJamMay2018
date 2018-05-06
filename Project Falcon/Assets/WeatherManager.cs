using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour {

    // Reference to partical system
    private ParticleSystem particalSystem;

    // Reference to the Tornado prefab
    [SerializeField]
    private GameObject tornadoPrefab;

    // Reference to the players
    private GameObject player;

    // Probability of creating a tornado (1/variable)
    [SerializeField]
    private int spawnProbability;

    // Probability of creating a tornado (1/variable)
    [SerializeField]
    private int rainProbability;


    // Use this for initialization
    void Start () {
		this.particalSystem = GetComponent<ParticleSystem>();
        this.player = GameObject.FindWithTag("anchor");
        this.SpawnTornado();
    }
	
	// Update is called once per frame
	void Update () {
        ChanceOfRain();
        ChanceOfSpawningTornado();
	}


    /// <summary>
    /// Probability of changing the weather occurs here
    /// </summary>
    void ChanceOfRain()
    {
        int changeChance = Random.Range(1, rainProbability);
        if (changeChance == rainProbability)
        {
            var emission = this.particalSystem.emission;
            emission.enabled = !emission.enabled;
        }
    }


    /// <summary>
    /// Determines the chance of spawning a tornado.
    /// </summary>
    void ChanceOfSpawningTornado()
    {
        Debug.Log("Spawning tornado chance");
        int spawnChance = Random.Range(1, spawnProbability+1);
        Debug.Log("Spawn Chance: " + spawnChance + " Spawn Prob: " + spawnProbability);
        if (spawnChance == spawnProbability)
        {
            Debug.Log("Should spawn tornado");
            SpawnTornado();
        }
    }



    /// <summary>
    /// SpawnTornado() will create a tornado
    /// </summary>
    void SpawnTornado()
    {
        Debug.Log("Spawning tornado");
        // Determine the starting wall position where 1 = top and go clockwise
        int wall = Random.Range(0, 4);

        // Position of the tornado
        int positionX = 0;
        int positionY = 0;
        
        if (wall == 1)
        {
            positionX = Random.Range(0, 200);
            positionY = 200;
        }
        else if (wall == 2)
        {
            positionY = Random.Range(0, 200);
            positionX = 200;
        }
        else if (wall == 3)
        {
            positionX = Random.Range(0, 200);
            positionY = 0;
        }
        else
        {
            positionY = Random.Range(0, 200);
            positionX = 0;
        }

        // Determine direction of the tornado
        float xDirection = DetermineTornadoXDirection(positionX, positionY);
        float yDirection = DetermineTornadoYDirection(positionX, positionY);

        // Instantiate tornado
        GameObject newTornado = Instantiate(this.tornadoPrefab, new Vector3(positionX, positionY, 0), Quaternion.identity);
        newTornado.GetComponent<Tornado>().SetDirectionalSpeeds(xDirection, yDirection);
    }


    /// <summary>
    /// DetermineTornadoXDirection() will determine the x direction the tornado shouls move
    /// </summary>
    /// <param name="currentX">starting position of the tornado</param>
    /// <param name="currentY">starting position of the tornado</param>
    float DetermineTornadoXDirection(float currentX, float currentY)
    {
        float direction = 0;

        // If the position of the tornado is on the left wall
        if(currentX <= 1)
        {
            direction = 10;
        }
        // If the position is on the right wall
        else if(currentX >= 200)
        {
            direction = -10;
        }
        else
        {
            direction = (this.player.transform.position.y - currentY)/10;
        }

        return direction;
    }


    /// <summary>
    /// DetermineTornadoYDirection() will determine the y direction the tornado shouls move
    /// </summary>
    /// <param name="currentX">starting position of the tornado</param>
    /// <param name="currentY">starting position of the tornado</param>
    float DetermineTornadoYDirection(float currentX, float currentY)
    {
        float direction = 0;

        // If the position of the tornado is on the bottom wall
        if (currentY <= 1)
        {
            direction = 10;
        }
        else if (currentY >= 200)
        {
            direction = -10;
        }
        else
        {
            direction = (this.player.transform.position.x - currentX) / 10;
        }

        return direction;
    }

}
