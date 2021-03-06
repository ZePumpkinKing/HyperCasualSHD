using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*------------------------------------------------------  Table of Contents  ----------------------------------------------------------
     


    ------------------------------------------------------  Variable Declarations  ------------------------------------------------------*/

    public float speed = 3.0f;
    public float turnSpeed = 200.0f;
    public float horizontalBound = 9.8f;
    public float upperBound = 6.4f;
    public float lowerBound = 4.4f;

    string direction = "forward";

    bool bounceTime = false;
    bool safeZone = false;

    public GameObject paint;
    private GameObject background;

    public int gemCount;

    /*-------------------------------------------------------  Start / Update  ----------------------------------------------------------*/

    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("Background");
    }

    // Update is called once per frame
    void Update()
    {
        // paints a mask that hides the background at the player every 3 frames
        if (int.Parse(Time.frameCount.ToString()) % 3 == 0 || int.Parse(Time.frameCount.ToString()) < 30) {
            if (!safeZone) {
                //Debug.Log("painting!");
                Instantiate(paint, transform.position, new Quaternion(), background.transform);
            }
        }

        // Manager for player movement
        if (!bounceTime) {
            if (transform.position.x > horizontalBound) {
                Bounce();
            } else if (transform.position.x < -horizontalBound) {
                Bounce();
            } else if (transform.position.y > upperBound) {
                Bounce();
            } else if (transform.position.y < -lowerBound) {
                Bounce();
            } else {
                if (Input.GetMouseButton(0)) {
                    direction = "counter";
                } else {
                    direction = "clockwise";
                }
            }
        }

        // Moves the player forward
        transform.Translate(0, -speed * Time.deltaTime, 0);

        // Movement direction filter
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hotRock")) {
            Debug.Log("Hit!");
            GameOver();
        }
        if (collision.gameObject.CompareTag("gem")) {
            Debug.Log("Shiny!");
            gemCount += 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "SafeZone")
        {
            // Debug.Log("safe!");
            safeZone = true;
            gemCount = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SafeZone")
        {
            safeZone = false;
        }
    }

    /*-----------------------------------------------------  Additional Functions  -------------------------------------------------------*/

    private IEnumerator BounceIE() {
        yield return new WaitForSeconds(0.25f);
        bounceTime = false;
    }
    
    void Bounce() {
        transform.Rotate(0, 0, 180f);
        bounceTime = true;
        StartCoroutine(BounceIE());
    }

    void GameOver() {
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }
}
