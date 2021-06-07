using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    Vector3 gravity = new Vector3(0, 9.8f, 0);
    bool isGrounded;

    void Start()
    {
        isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //apply jumpforce
            velocity = new Vector3(0, 10, 0);
        }

        //apply velocity to players position
        transform.position += velocity * Time.deltaTime;

        //apply gravity to reduce players velocity
        transform.position -= gravity * Time.deltaTime;

        if (Vector3.y > 0)
        {
            isGrounded = false;
        }
        
        // when the player is on the ground
        if (isGrounded)
        {
          velocity = Vector3.zero;
          gravity = Vector3.zero;
        }
    }
}
