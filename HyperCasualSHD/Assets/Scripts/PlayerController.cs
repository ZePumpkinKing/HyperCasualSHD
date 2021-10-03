using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*------------------------------------------------------  Table of Contents  ----------------------------------------------------------
     


    ------------------------------------------------------  Variable Declarations  ------------------------------------------------------*/

    public float speed = 3.0f;
    public float turnSpeed = 150.0f;

    string direction = "forward";

    /*-------------------------------------------------------  Start / Update  ----------------------------------------------------------*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 3.4 || transform.position.x < -3.4)
        {
            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = "clockwise";
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = "counter";
        } else
        {
            direction = "forward";
        }

        switch (direction)
        {
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

        if (transform.rotation.z > -90 || transform.rotation.z < 90) {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        } else {
            Debug.Log("can't dig");
        }
    }

    /*-----------------------------------------------------  Additional Functions  -------------------------------------------------------*/
    


}
