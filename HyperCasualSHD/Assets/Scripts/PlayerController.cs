using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*------------------------------------------------------  Table of Contents  ----------------------------------------------------------
     
        1. Variable Declarations
        2. Start / Update
        3. Additional Functions

    ------------------------------------------------------  Variable Declarations  ------------------------------------------------------*/

    public float speed = 3.0f;
    public float turnSpeed = 150.0f;

    string direction = "forward";

    bool bounceTime = false;

    /*-------------------------------------------------------  Start / Update  ----------------------------------------------------------*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Manager for player movement
        if (!bounceTime) {
            if (transform.position.x > 3.4) {
                direction = "counter";
            } else if (transform.position.x < -3.4) {
                direction = "clockwise";
            } else {
                if (Input.GetKey(KeyCode.LeftArrow)) {
                    direction = "clockwise";
                } else if (Input.GetKey(KeyCode.RightArrow)) {
                    direction = "counter";
                } else {
                    direction = "forward";
                }
            }
        }

        // Moves the player forward and flips the player when they reach too steep of an angle
        if (transform.rotation.z > -0.71 && transform.rotation.z < 0.71) {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        } else {
            Bounce();
        }

        // Movement execution
        switch (direction) {
            case "counter":
                transform.Rotate(0,0,turnSpeed*Time.deltaTime);
                break;
            case "clockwise":
                transform.Rotate(0, 0, -turnSpeed * Time.deltaTime);
                break;
            case "forward":
            default:
                break;
        }
    }

    /*-----------------------------------------------------  Additional Functions  -------------------------------------------------------*/
    
    private IEnumerator BounceIE() {
        yield return new WaitForSeconds(0.5f);
        bounceTime = false;
    }

    void Bounce() {
        bounceTime = true;
        transform.Rotate(0, 0, 180);
        StartCoroutine(BounceIE());
    }
}
