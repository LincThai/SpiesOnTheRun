using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //set variables
    public float moveSpeed = 1f;
    public float timePassed;
    public float despawnTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed <= despawnTime)
        {
            Destroy(gameObject);
            timePassed = 0.0f;
        }

        transform.position = transform.position + (Vector3.forward * -moveSpeed * Time.deltaTime);
    }
}
