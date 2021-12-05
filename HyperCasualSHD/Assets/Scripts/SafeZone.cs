using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gem"))
        {
            Collect(other);
        }
    }

    void Collect(Collider2D gem)
    {
        door.transform.localScale = new Vector3(1,1,1);
    }
}
