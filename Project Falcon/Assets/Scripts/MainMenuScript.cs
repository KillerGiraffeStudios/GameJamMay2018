using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public GameObject startText;
    public GameObject redText;

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
           Debug.Log("Key pressed");
           StartCoroutine(ChangeTextColour());
        }
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
            Debug.Log("Starting Coroutine");
            StartCoroutine(FlipLetter(letter));
        }
    }

    /// <summary>
    /// Change one letter to red
    /// </summary>
    /// <param name="letter"></param>
    private IEnumerator FlipLetter(Transform letter)
    {
        yield return new WaitForSeconds(0.001f);

        letter.gameObject.SetActive(true);
        Debug.Log("Set Text Active");
    }



    /// <summary>
    /// Start the scene containing the game with any necessary parameters
    /// </summary>
    void StartGame()
    {
        // Start the game scene here
    }
}
