using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //set variables
    public float moveSpeed = 1f;
    public float timePassed;
    public float despawnTime = 50;
    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0.0f;
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Functions only when in game
        if (GM.gameState == GameState.game)
        {
            // increases timePassed variable value
            timePassed += Time.deltaTime;

            if (timePassed >= despawnTime)
            {
                //destroys obstacle
                Destroy(gameObject);
                timePassed = 0.0f;
            }

            transform.position = transform.position + (Vector3.forward * -moveSpeed * Time.deltaTime);
        }
        // reset obstacles in the game
        if (GM.wasDead)
        {
            Destroy(gameObject);
        }
    }
}
