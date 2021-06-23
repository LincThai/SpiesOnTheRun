using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // set variables
    //Numeric values
    public float moveSpeed = 1;
    public float endPosition = 20.0f;
    // game manager variabl;e
    GameManager GM;


    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // when in gameState.game the fol;lowing happens
        if (GM.gameState == GameState.game)
        {
            transform.position = transform.position + (Vector3.back * moveSpeed * Time.deltaTime);

            // when the platform reaches a certain point it moves back
            if (transform.position.z <= -endPosition)
            {
                transform.position = transform.position + (Vector3.forward * endPosition * 2);
            }
        }
    }
}
