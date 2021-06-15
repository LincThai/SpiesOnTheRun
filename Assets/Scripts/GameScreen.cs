using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{   
    // set variables
    public int playerScore;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerScore = playerScore + 1;

        scoreText.text = playerScore.ToString();
    }
}
