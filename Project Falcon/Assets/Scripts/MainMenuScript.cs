using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public GameObject startText;
    public GameObject redText;

    public List<Transform> numberOfPlayersText;
    public List<Transform> difficultiesTexts;



    // Seconds
    public float startTextBlinkTime = 1;


    private int numberOfPlayers = 1;
    private int difficulty = 1;

    public static float textColourTimerValue = 15f;

    bool canChangeNumPlayers = true;
    bool canChangeDifficulty = true;

    private float numPlayersTimer = 0f;
    private float difficultyTimer = 0f;

    private float textColourTimer = textColourTimerValue;
    private bool textIsRed = false;

	// Use this for initialization
	void Start () {
        InvokeRepeating("AnimateStartText", startTextBlinkTime, startTextBlinkTime);
	}
	


	// Update is called once per frame
	void Update () {

        Reset();

        if (textColourTimer <= 0)
        {
 
            StartCoroutine(ChangeTextColour());
    
            if (textIsRed)
            {
                textColourTimer = 3f;
            }
            else {
                textColourTimer = textColourTimerValue;
            }
           
        }


        // THIS IS HERE FOR EASY TESTING REPLACE WITH CONTROLLER STUFF

        if (canChangeNumPlayers)
        {
            if (Input.GetKey("up"))
            {
                numberOfPlayers = ChangeNumberOfPlayers(1);
            }

            if (Input.GetKey("down"))
            {
                numberOfPlayers = ChangeNumberOfPlayers(-1);
            }

            canChangeNumPlayers = false;
            numPlayersTimer = 0.25f;
        }

        if (canChangeDifficulty)
        {

            if (Input.GetKey("left"))
            {
                difficulty = ChangeDifficulty(-1);
            }

            if (Input.GetKey("right"))
            {
                difficulty = ChangeDifficulty(1);
            }

            canChangeDifficulty = false;
            difficultyTimer = 0.25f;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            StartGame(numberOfPlayers, difficulty);
        }

	}

    private void Reset()
    {
        if (!canChangeDifficulty && difficultyTimer <= 0)
        {
            canChangeDifficulty = true;
        }
        else
        {
            difficultyTimer -= Time.deltaTime;
        }

        if (!canChangeNumPlayers && numPlayersTimer <= 0)
        {
            canChangeNumPlayers = true;
        }
        else
        {
            numPlayersTimer -= Time.deltaTime;
        }

        textColourTimer -= Time.deltaTime;

    }

    private int ChangeDifficulty(int direction)
    {
        Transform currentActive = null;

        foreach (Transform text in difficultiesTexts)
        {
            if (text.gameObject.activeSelf)
            {
                currentActive = text;
            }
        }



        if (direction > 0)
        {

            int next = difficultiesTexts.IndexOf(currentActive) + 1;


            if (next >= difficultiesTexts.Count)
            {
                next = 0;
            }

            switch (currentActive.name)
            {
                case "RustyRabbit":
                    currentActive.gameObject.SetActive(false);

                    difficultiesTexts[next].gameObject.SetActive(true);
                    return 2;

                case "CarefulCamel":
                    currentActive.gameObject.SetActive(false);
                    difficultiesTexts[next].gameObject.SetActive(true);
                    return 3;

                case "AbleAardvark":
                    currentActive.gameObject.SetActive(false);
                    difficultiesTexts[next].gameObject.SetActive(true);
                    return 4;

                case "SeriousSquirrel":
                    currentActive.gameObject.SetActive(false);
                    difficultiesTexts[next].gameObject.SetActive(true);
                    return 5;

                case "BallsyBadger":
                    currentActive.gameObject.SetActive(false);
                    difficultiesTexts[next].gameObject.SetActive(true);
                    return 1;

            }
        }
        else if (direction < 0)
        {
            int prev = difficultiesTexts.IndexOf(currentActive) - 1;

            if (prev < 0)
            {
                prev = difficultiesTexts.Count - 1;
            }


            switch (currentActive.name)
            {
                case "RustyRabbit":
                    currentActive.gameObject.SetActive(false);

                    difficultiesTexts[prev].gameObject.SetActive(true);
                    return 5;

                case "CarefulCamel":
                    currentActive.gameObject.SetActive(false);
                    difficultiesTexts[prev].gameObject.SetActive(true);
                    return 1;

                case "AbleAardvark":
                    currentActive.gameObject.SetActive(false);
                    difficultiesTexts[prev].gameObject.SetActive(true);
                    return 2;

                case "SeriousSquirrel":
                    currentActive.gameObject.SetActive(false);
                    difficultiesTexts[prev].gameObject.SetActive(true);
                    return 3;

                case "BallsyBadger":
                    currentActive.gameObject.SetActive(false);
                    difficultiesTexts[prev].gameObject.SetActive(true);
                    return 4;


            }
        }

        return 1;
    }

    private int ChangeNumberOfPlayers(int direction)
    {

        Transform currentActive = null;

        foreach(Transform text in numberOfPlayersText)
        {
            if (text.gameObject.activeSelf)
            {
                currentActive = text;
            }
        }

        

        if (direction > 0)
        {

            int next = numberOfPlayersText.IndexOf(currentActive) + 1;

            if (next >= numberOfPlayersText.Count)
            {
                next = 0;
            }

            switch (currentActive.name)
            {
                case "One":
                    currentActive.gameObject.SetActive(false);
                   
                    numberOfPlayersText[next].gameObject.SetActive(true);
                    return 2;

                case "Two":
                    currentActive.gameObject.SetActive(false);
                    numberOfPlayersText[next].gameObject.SetActive(true);
                    return 3;

                case "Three":
                    currentActive.gameObject.SetActive(false);
                    numberOfPlayersText[next].gameObject.SetActive(true);
                    return 4;

                case "Four":
                    currentActive.gameObject.SetActive(false);
                    numberOfPlayersText[next].gameObject.SetActive(true);
                    return 1;


            }
        }
        else if(direction < 0)
        {
            int prev = numberOfPlayersText.IndexOf(currentActive) - 1;

            if (prev < 0)
            {
                prev = numberOfPlayersText.Count - 1;
            }

            switch (currentActive.name)
            {
                case "One":
                    currentActive.gameObject.SetActive(false);

                    numberOfPlayersText[prev].gameObject.SetActive(true);
                    return 4;

                case "Two":
                    currentActive.gameObject.SetActive(false);
                    numberOfPlayersText[prev].gameObject.SetActive(true);
                    return 1;

                case "Three":
                    currentActive.gameObject.SetActive(false);
                    numberOfPlayersText[prev].gameObject.SetActive(true);
                    return 2;

                case "Four":
                    currentActive.gameObject.SetActive(false);
                    numberOfPlayersText[prev].gameObject.SetActive(true);
                    return 3;


            }
        }

        return 1;
    }

    /// <summary>
    /// Blinking animation for start game text
    /// </summary>
    private void AnimateStartText()
    {
        if (startText.activeSelf)
        {
            startText.SetActive(false);
        }
        else
        {
            startText.SetActive(true);
        }
    }

    /// <summary>
    /// Start the text animation for the start of the game
    /// </summary>
    private IEnumerator ChangeTextColour()
    {
        if (textIsRed)
        {
            foreach (Transform letter in redText.transform)
            {
                StartCoroutine(FlipLetter(letter));
            }

            textIsRed = false;
        }
        else
        {
            foreach (Transform letter in redText.transform)
            {
                yield return new WaitForSeconds(0.25f);
                StartCoroutine(FlipLetter(letter));
            }

            textIsRed = true;

            textColourTimer = 2f;
        }

    }

    /// <summary>
    /// Change one letter to red
    /// </summary>
    /// <param name="letter"></param>
    private IEnumerator FlipLetter(Transform letter)
    {
        yield return new WaitForSeconds(0.001f);

        letter.gameObject.SetActive(!letter.gameObject.activeSelf);
    }



    /// <summary>
    /// Start the scene containing the game with any necessary parameters
    /// </summary>
    void StartGame(int numberOfPlayers, int difficulty)
    {
        // Start the game scene here
        Debug.Log(numberOfPlayers);
        GlobalValues.numPlayers = numberOfPlayers;
        GlobalValues.difficulty = difficulty;
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        // TODO Pass the number of players and difficulty to the meta and pcg scripts
    }
}
