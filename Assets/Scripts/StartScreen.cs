using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when a button is clicked
    public void OnClickButton(int buttonClicked)
    {
        if (buttonClicked == 1)
        {
            GM.gameState = GameState.game;
        }
        if (buttonClicked == 2)
        {
            Application.Quit();
        }
    }
}
