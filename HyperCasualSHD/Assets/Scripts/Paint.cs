using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.magnitude >= 0.5)
        {
            transform.localScale *= 0.99f;
        } else {
            Destroy(gameObject);
        }
    }
}
