using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton(int buttonClicked)
    {
        gameStste = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().gameState;

        if (buttonClicked == 1)
        {

        }
        if (buttonClicked == 2)
        {

        }
    }
}
