using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //Set list
    public List<GameObject> obstacleList;

    //set variables
    public int x;
    public float z;
    int i;
    public float timeTillSpawn = 7.5f;
    public float timePassed;
    
    public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        z = transform.position.z;
        canSpawn = true;
        timePassed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        //ObstacleSpawn();
        if (canSpawn)
        {
            ObstacleSpawn();
            canSpawn = false;
        }

        if (timePassed >= timeTillSpawn)
        {
            canSpawn = true;
            timePassed = 0.0f;
        }
    }

    private void ObstacleSpawn()
    {
        //get random value for x
        x = Random.Range(-1, 2);
        //Debug.Log(x);

        //get random value for i
        i = Random.Range(0, 5);
        //Debug.Log(i);

        //make variable spawnRotate
        Quaternion spawnRotate = new Quaternion();
        spawnRotate = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        if (i == 4)
        {
            spawnRotate = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }

        Instantiate(obstacleList[i], new Vector3(x, 0, z), spawnRotate);
    }
}