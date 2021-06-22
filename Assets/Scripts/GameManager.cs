using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public GameObject startGUI;
    public GameObject gameGUI;
    public GameObject pauseGUI;
    public GameObject endGUI;
    

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.preGame;
        startGUI.SetActive(true);
        gameGUI.SetActive(false);
        pauseGUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.preGame)
        {
            endGUI.SetActive(false);
            pauseGUI.SetActive(false);
            startGUI.SetActive(true);
        }
        else if (gameState == GameState.game)
        {
            startGUI.SetActive(false);
            pauseGUI.SetActive(false);
            gameGUI.SetActive(true);
        }
        else if (gameState == GameState.dead)
        {
            gameGUI.SetActive(false);
            endGUI.SetActive(true);
        }
        else if (gameState == GameState.pause)
        {
            gameGUI.SetActive(false);
            pauseGUI.SetActive(true);
        }
    }
}

public enum GameState { preGame, game, dead, pause };