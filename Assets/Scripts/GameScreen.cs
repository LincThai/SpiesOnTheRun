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

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0; 
    }

    // Update is called once per frame
    void Update()
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

    public void ClickButton(int buttonClicked)
    {
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().gameState;

        if (buttonClicked == 1)
        {

        }
    }
}
