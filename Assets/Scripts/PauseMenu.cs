using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        //reference game manager
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // when then button is clicked it completes the function
    public void OnClickButton(int buttonClicked)
    {
        if (buttonClicked == 1)
        {
            GM.gameState = GameState.game;
        }
        if (buttonClicked == 2)
        {
            GM.gameState = GameState.preGame;
            GM.wasDead = true;
        }
    }
}