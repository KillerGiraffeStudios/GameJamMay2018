using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public GameObject startText;

    // Seconds
    public float startTextBlinkTime = 1;    

	// Use this for initialization
	void Start () {
        InvokeRepeating("AnimateStartText", startTextBlinkTime, startTextBlinkTime);
	}
	
	// Update is called once per frame
	void Update () {
		
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
    /// Start the scene containing the game with any necessary parameters
    /// </summary>
    void StartGame()
    {
        // Start the game scene here
    }
}
