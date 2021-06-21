using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // set variables
    public float velocity = 5;
    public float gravity = 3;
    public float fallHeight = 2;
    
    // Position Variables
    public GameObject laneOne;
    public GameObject laneTwo;
    public GameObject laneThree;

    // Player variable
    public bool isDead;
    public bool isGrounded;

    // collider variables to change colliders
    public float capsuleHeightOne;
    public float capsuleHeightTwo;
    

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
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            PlayerPosition();
            PlayerSlide();
            PlayerJump();
        }
    }

    // when player runs/collides into something
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            isDead = true;
            Debug.Log("Dead");
        }
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public void PlayerJump()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * velocity * Time.deltaTime;

            isGrounded = false;
        }
        if (transform.position.y >= fallHeight || !isGrounded)
        {
            transform.position -= Vector3.up * gravity * Time.deltaTime;
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