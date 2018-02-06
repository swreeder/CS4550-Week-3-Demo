using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    //Array of objects to spawn
    public GameObject[] theTargets;
    //public GameObject Moon;
    //Time it takes to spawn theTargets
    public float waitingForNextSpawn;
    public float theCountdown;
    // the range of X
    public float xMin;
    public float xMax;
    // the range of y
    public float yMin;
    public float yMax;
    //public Text score;
    //public Text winText;
    void Start()

    {

    }

    public void Update()

    {
        // timer to spawn the next Target Object
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0 && PlayerController.gameOver == false)
        {
            SpawnTargets();
            theCountdown = waitingForNextSpawn;
        }
    }

    void SpawnTargets()

    {
        // Defines the min and max ranges for x and y
        Vector2 pos = new Vector2(UnityEngine.Random.Range(xMin, xMax), UnityEngine.Random.Range(yMin, yMax));
        // Choose a new targets to spawn from the array (note I specifically call it a 'prefab' to avoid confusing myself!)
        GameObject targetsPrefab = theTargets[UnityEngine.Random.Range(0, theTargets.Length)];
        // Creates the random object at the random 2D position.
        Instantiate(targetsPrefab, pos, transform.rotation);
        // If I wanted to get the result of instantiating and fiddle with it, I might do this instead:
        //GameObject newTargets = (GameObject)Instantiate(targetsPrefab, pos)
        //newtargets.something = somethingelse;
    }
}

