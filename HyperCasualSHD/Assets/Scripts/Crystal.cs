using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.position = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("clink!");
        player = collision.gameObject;
    }
}
