using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaController : MonoBehaviour
{
    Transform[] rocks;
    public GameObject hotRock;

    // Start is called before the first frame update
    void Start()
    {
        rocks = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        int rockCount = 0;
        rocks = GetComponentsInChildren<Transform>();

        foreach (Transform rock in rocks)
        {
            if (rock.name == "MagmaController") {
                
            } else {
                rockCount += 1;
                Debug.Log(rockCount);
            }
        }

        if (rockCount < 5)
        {
            SpawnRock();
        }
    }

    void SpawnRock()
    {
        Instantiate(hotRock, NewPosition(), new Quaternion(), transform);
    }

    Vector3 NewPosition()
    {
        Vector3 position = new Vector3(Random.Range(-9f, 9f), Random.Range(-4, 6), -0.3f);
        return position;
    }
}
