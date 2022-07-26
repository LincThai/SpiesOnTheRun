using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // set variables
    public float velocity = 5;
    public float gravity = 3;
    public float fallHeight = 2;
    
    // Lane Position Variables
    public GameObject laneOne;
    public GameObject laneTwo;
    public GameObject laneThree;

    // Ground Check Variables
    public GameObject groundCheck;
    public float GCheckRadius;

    // Player variable
    public bool isDead;
    public bool isGrounded;

    // collider variables to change colliders
    public float capsuleHeightOne;
    public float capsuleHeightTwo;

    // game state variavle
    GameManager GM;
    

    // Start is called before the first frame update
    void Start()
    {   
        // player state
        isDead = false;
        isGrounded = true;
        // set the players collider to standing state
        // the Change height of the collider to the first setb
        gameObject.GetComponent<CapsuleCollider>().height = capsuleHeightOne;
        // get children of player game object and set game object state
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        // Reference Game Manager
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // when in gamestate.game
        if (GM.gameState == GameState.game)
        {
            //if player nis not dead
            if (!isDead)
            {
                // call functions
                PlayerPosition();
                PlayerSlide();
                PlayerJump();
                GroundCheck();
            }
            else
            {
                // change game state to dead
                GM.gameState = GameState.dead;
            }
        }
    }

    // when player runs/collides into something
    public void OnTriggerEnter(Collider other)
    {
        // check if the game object that has collided is an obstacle
        if (other.tag == "Obstacle")
        {
            isDead = true;
            Debug.Log("Dead");
        }
    }

    public void GroundCheck()
    {
        // use physics checksphere to check if player is grounded
        if (Physics.CheckSphere(groundCheck.transform.position, GCheckRadius))
        {
            isGrounded = true;
        }
    }

    // makes player jump
    public void PlayerJump()
    {
        // makes the player move up non y axis
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * velocity * Time.deltaTime;

            isGrounded = false;
        }
        // makes the player move down on y axis
        if (transform.position.y >= fallHeight || !isGrounded)
        {
            transform.position -= Vector3.up * gravity * Time.deltaTime;
        }
        // stops player from moving higher
        if (transform.position.y >= fallHeight)
        {
            transform.position = new Vector3 (transform.position.x, fallHeight, transform.position.z);
        }
    }

    public void PlayerSlide()
    {
        if (Input.GetKey(KeyCode.S))
        {
            // set the player avatar's collider to crouch/slide state
            gameObject.GetComponent<CapsuleCollider>().height = capsuleHeightTwo;
            // changes the orientation of the player avatar by changing which child is active
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            // set the player avatar's collider to crouch/slide state
            gameObject.GetComponent<CapsuleCollider>().height = capsuleHeightOne;
            // changes the orientation of the player avatar by changing which child is active
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    // player movement between lanes
    public void PlayerPosition()
    {
        // when the player is in a certain position
        if (transform.position.x == laneOne.transform.position.x)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position = laneOne.transform.position;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = laneTwo.transform.position;
            }
        }
        
        else if (transform.position.x == laneTwo.transform.position.x)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position = laneOne.transform.position;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = laneThree.transform.position;
            }
        }

        else if (transform.position.x == laneThree.transform.position.x)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position = laneTwo.transform.position;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = laneThree.transform.position;
            }
        }
    }
}