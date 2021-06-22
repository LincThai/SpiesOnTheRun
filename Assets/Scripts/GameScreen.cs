using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{   
    // set variables
    public int playerScore;
    public Text scoreText;
    public bool isDead;
    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.gameState == GameState.game)
        { 
            isDead = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isDead;
        
            if (!isDead)
            {
                // increase the player score by 1
                playerScore = playerScore + 1;

                // display the score
                scoreText.text = playerScore.ToString();
            }
        }
    }

    public void ClickButton(int buttonClicked)
    {

        if (buttonClicked == 1)
        {
            GM.gameState = GameState.pause;
        }
    }
}
