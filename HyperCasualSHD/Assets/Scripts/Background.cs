using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    /*------------------------------------------------------  Table of Contents  ----------------------------------------------------------
     
        1. Variable Declarations
        2. Unity Functions
        3. Additional Functions

    ------------------------------------------------------  Variable Declarations  ------------------------------------------------------*/

    private GameObject player;

    /*-------------------------------------------------------  Unity Functions  ---------------------------------------------------------*/

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // at player position paint a black dot every frame

        // if height is above playspace, delete cube
        if (false) { 

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player) {
            nextLevel();
        }
    }

    /*-----------------------------------------------------  Additional Functions  -------------------------------------------------------*/

    private void nextLevel()
    {
        Debug.Log("Shifting to next level");
        // generate new obstacles and place them on the new block
        // wait for new block to reach playspace
        // parent other blocks and player to it
        // move up
    }
}
