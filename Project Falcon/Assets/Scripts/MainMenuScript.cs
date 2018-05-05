using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public GameObject startText;
    public GameObject redText;

    public List<Transform> numberOfPlayersText;
    public GameObject difficultyRatingText;

    // Seconds
    public float startTextBlinkTime = 1;    

	// Use this for initialization
	void Start () {
        InvokeRepeating("AnimateStartText", startTextBlinkTime, startTextBlinkTime);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
 
           StartCoroutine(ChangeTextColour());
        }

        if (Input.GetKey("up"))
        {
            ChangeNumberOfPlayers(1);
        }

        if (Input.GetKey("down"))
        {
            ChangeNumberOfPlayers(-1);
        }

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
        foreach (Transform letter in redText.transform)
        {
            yield return new WaitForSeconds(0.25f);
            StartCoroutine(FlipLetter(letter));
        }

        StartGame();
    }

    /// <summary>
    /// Change one letter to red
    /// </summary>
    /// <param name="letter"></param>
    private IEnumerator FlipLetter(Transform letter)
    {
        yield return new WaitForSeconds(0.001f);

        letter.gameObject.SetActive(true);
    }



    /// <summary>
    /// Start the scene containing the game with any necessary parameters
    /// </summary>
    void StartGame()
    {
        // Start the game scene here
    }
}
