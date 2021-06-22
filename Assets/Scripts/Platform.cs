using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // set variables
    public float moveSpeed = 1;
    public float endPosition = 20.0f;

    GameManager GM;


    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.gameState == GameState.game)
        {
            transform.position = transform.position + (Vector3.back * moveSpeed * Time.deltaTime);

            if (transform.position.z <= -endPosition)
            {
                transform.position = transform.position + (Vector3.forward * endPosition * 2);
            }
        }
    }
}
