using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // set variables
    public float jumpSpeed = 2;
    
    // Position Variables
    public GameObject laneOne;
    public GameObject laneTwo;
    public GameObject laneThree;

    // Player variable
    public bool isDead;
    public bool isGrounded;

    // collider variables to change colliders
    public Collider capOne;
    public Collider capTwo;
    private GameObject playerChildOne;
    private GameObject playerChildTwo;

    // Start is called before the first frame update
    void Start()
    {   
        // player state
        isDead = false;
        // set the players collider to standing state
        // the first collider is turned on while the second off on the player avatar
        capOne.enabled = capOne.enabled;
        capTwo.enabled = !capTwo.enabled;
        // get children of player game object
        //playerChildOne = transform.GetChild(0);
        //playerChildTwo = transform.GetChild(1);
        // set game object state
        playerChildOne.SetActive(true);
        playerChildTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            PlayerPosition();
            PlayerSlide();
        }
    }

    // when player runs/collides into something
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            isDead = true;
        }
    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

        }
    }

    public void PlayerSlide()
    {
        if (Input.GetKey(KeyCode.S))
        {
            // set the player avatar's collider to crouch/slide state
            capOne.enabled = !capOne.enabled;
            capTwo.enabled = capTwo.enabled;
            Debug.Log("Collider enabled = " + capOne.enabled + capTwo.enabled);
            // changes the orientation of the player avatar by changing which child is active
            playerChildOne.SetActive(false);
            playerChildTwo.SetActive(true);
        }
    }

    // player movement between lanes
    public void PlayerPosition()
    {
        // when the player
        if (transform.position == laneOne.transform.position)
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
        
        else if (transform.position == laneTwo.transform.position)
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

        else if (transform.position == laneThree.transform.position)
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