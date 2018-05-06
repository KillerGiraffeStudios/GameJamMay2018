using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GamepadInput;

public class DeathScreenScript : MonoBehaviour {

    public Text oakTreesBurned;
    public Text rabbitsSlaughtered;
    public Text catsKilled;
    public Text squirrelsMurdered;
    public Text bearsIncinerated;
    public GamePad.Index Player = GamePad.Index.Any;

    [SerializeField]
    public GameObject mainMenuText;

    public GameObject playAgainText;

    public float textBlinkTime = 1;

    GameObject curSelected = null;

	// Use this for initialization
	void Start () {
        SetScoreValues(GlobalValues.oakTreesKilled, GlobalValues.rabbitsKilled, GlobalValues.catsKilled, GlobalValues.squirrelsKilled, GlobalValues.bearsKilled);
        curSelected = playAgainText;
        InvokeRepeating("Blink", textBlinkTime, textBlinkTime);
	}
    Vector2 leftStick;
	// Update is called once per frame
	void Update () {
        leftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, Player);

        if (Input.GetKey("left") || Input.GetKey("right") || leftStick.x>0 || leftStick.x<0)
        {
            if (curSelected == mainMenuText)
            {
                curSelected = playAgainText;
                mainMenuText.SetActive(true);
            }
            else
            {
                curSelected = mainMenuText;
                playAgainText.SetActive(true);
            }
        }

        if (Input.GetKey(KeyCode.Return) || GamePad.GetButtonDown(GamePad.Button.Start, Player))
        {
            if(curSelected == playAgainText)
            {
                RestartGame();
            }
            else
            {
                MainMenu();
            }
        }

	}

    public void RestartGame()
    {
        Debug.Log("Restart the Game");
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void Blink()
    {
        Debug.Log("Blink");
        Debug.Log(curSelected.name);
        curSelected.gameObject.SetActive(!curSelected.gameObject.activeSelf);
    }

    public void SetScoreValues(int oakTrees, int rabbits, int cats, int squirrels, int bears)
    {
        oakTreesBurned.text = oakTrees.ToString();
        rabbitsSlaughtered.text = rabbits.ToString();
        catsKilled.text = cats.ToString();
        bearsIncinerated.text = bears.ToString();
        squirrelsMurdered.text = squirrels.ToString();
    }
}
