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
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

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