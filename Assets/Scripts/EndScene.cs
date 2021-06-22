using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    // set variables
    GameManager GM;
    public int finalScore;
    public Text scoreText;

    // Start is called before the first frame update
    void Update()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (GM.gameState == GameState.dead)
        {
            finalScore = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameScreen>().playerScore;
            Debug.Log(finalScore);
            scoreText.text = finalScore.ToString();
        }
    }

    public void OnClickButton(int buttonClicked)
    {
        if (buttonClicked == 1)
        {
            GM.gameState = GameState.preGame;
        }
    }
}