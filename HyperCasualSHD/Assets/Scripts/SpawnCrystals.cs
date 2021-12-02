using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrystals : MonoBehaviour
{
    public GameObject gem;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gem, transform.position, new Quaternion(0,0,0,0), transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
