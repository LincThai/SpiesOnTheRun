using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Set Variables
    //UI variables
    public GameState gameState;
    public GameObject startGUI;
    public GameObject gameGUI;
    public GameObject pauseGUI;
    public GameObject endGUI;
    // Variables to reset game
    public bool wasDead;
    GameObject originPosition;
    GameObject player;
    Player PS;
    

    // Start is called before the first frame update
    void Start()
    {
        // set the starting game state
        gameState = GameState.preGame;
        // set all GUI's to these activate and deactivate
        startGUI.SetActive(true);
        gameGUI.SetActive(false);
        pauseGUI.SetActive(false);
        endGUI.SetActive(false);
        // set wasDead variable value
        wasDead = false;
        originPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().laneTwo;
        player = GameObject.FindGameObjectWithTag("Player");
        PS = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // when the gamen states change
        if (gameState == GameState.preGame)
        {
            endGUI.SetActive(false);
            pauseGUI.SetActive(false);
            startGUI.SetActive(true);
            // resets the game
            if (wasDead)
            {
                player.transform.position = originPosition.transform.position;
                wasDead = false;
                PS.isDead = false;
            }
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
            wasDead = true;
        }
        else if (gameState == GameState.pause)
        {
            gameGUI.SetActive(false);
            pauseGUI.SetActive(true);
        }
    }
}

public enum GameState { preGame, game, dead, pause };