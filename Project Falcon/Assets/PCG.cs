using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCG : MonoBehaviour {

    public GameObject cliff;
    public GameObject tree;
    public GameObject pine1;
    public GameObject pine2;
    public GameObject normal1;
    public GameObject normal2;
    public GameObject marsh1;
    public GameObject marsh2;
    public GameObject nestTree;

    private bool[,] map;
    public int arrayLengthx = 100;
    public int arrayLengthy = 100;

    public int difficulty = 2;

    [SerializeField]
    private int chanceToStartAlive = 40;
    [SerializeField]
    private int deathLimit = 3;
    [SerializeField]
    private int birthLimit = 4;
    [SerializeField]
    private int numSteps = 6;

    // Use this for initialization
    void Start () {
        difficulty = GlobalValues.difficulty * GlobalValues.numPlayers;
        map = new bool[arrayLengthx, arrayLengthy];
        initialiseMap();
        for (int i = 0; i < numSteps; i++)
        {
            map = updateForest();
        }
        addNestTrees();
        instantiateTrees();
    }

    public void addNestTrees()
    {
        int nestTreesLeft = difficulty;
        while(nestTreesLeft > 0)
        {
           
            int x = Random.Range(5, arrayLengthx - 5);
            int y = Random.Range(5, arrayLengthy - 5);
            if (!map[x, y])
            {
                for(int i=x-1; i < x+1; i++)
                {
                    for (int j = y - 1; j < x + 1; j++)
                    {
                        map[i, j] = true;
                    }
                }
                Instantiate(nestTree, new Vector2(x,y), Quaternion.identity);
                nestTreesLeft--;
            }

            
        }
    }

    public void instantiateTrees()
    {
        int xStart = (int)gameObject.transform.position.x * arrayLengthx;
        int yStart = (int)gameObject.transform.position.y * arrayLengthy;
        GameObject temp;
        for (int x = -1; x < arrayLengthx + 1; x++)
        {

            for (int y = -1; y < arrayLengthy + 1; y++)
            {

                if (y == -1 || x == -1 || y == arrayLengthy || x == arrayLengthx)
                {
                    temp = Instantiate(cliff, new Vector3(x + xStart, y + yStart), Quaternion.identity);
                    
                }
                else {
                    if (!map[x, y])
                    {
                        temp = Instantiate(tree, new Vector2(x + xStart, y + yStart), Quaternion.identity);
                        
                    }
                }
            }

        }
    }

    public bool[,] updateForest()
    {
        bool[,] newCave = new bool[arrayLengthx, arrayLengthy];
        for (int x = 0; x < arrayLengthx; x++)
        {
            for (int y = 0; y < arrayLengthy; y++)
            {
                if (map[x, y])
                {
                    if (countAliveNeighbours(x, y) < deathLimit)
                    {
                        newCave[x, y] = false;
                    }
                    else
                    {
                        newCave[x, y] = true;
                    }
                }
                else
                {
                    if (countAliveNeighbours(x, y) > birthLimit)
                    {
                        newCave[x, y] = true;
                    }
                    else
                    {
                        newCave[x, y] = false;
                    }
                }
            }
        }
        return newCave;
    }

    public void initialiseMap()
    {

        for (int x = 0; x < arrayLengthx; x++)
        {
            for (int y = 0; y < arrayLengthy; y++)
            {
                int randNum = Random.Range(0, 100);
                if (randNum < chanceToStartAlive)
                {

                    map[x, y] = true;
                }
                else
                {
                    map[x, y] = false;
                }
            }
        }
    }

    public int countAliveNeighbours(int x, int y)
    {
        int count = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int neighbourx = x + i;
                int neighboury = y + j;


                if (i == 0 && j == 0)
                {
                    //Do nothing, we don't want to add ourselves in!
                }
                //In case the index we're looking at it off the edge of the map
                else if (neighbourx < 0 || neighboury < 0 || neighbourx >= arrayLengthx - 1 || neighboury >= arrayLengthy - 1)
                {
                    count = count + 1;
                }
                //Otherwise, a normal check of the neighbour
                else if (map[neighbourx, neighboury])
                {
                    count = count + 1;
                }
            }
        }
        return count;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
