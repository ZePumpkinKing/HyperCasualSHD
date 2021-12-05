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
        if (GameObject.FindGameObjectsWithTag("hotRock").Length < 5)
        {
            SpawnRock();
            // Debug.Log("eruption!");
        }
    }

    void SpawnRock()
    {
        GameObject rock = Instantiate(hotRock, NewPosition(), new Quaternion(), transform);
        rock.transform.localScale = new Vector3(0f,0f,0f);
    }

    Vector3 NewPosition()
    {
        Vector3 position = new Vector3(Random.Range(-9f, 9f), Random.Range(-4, 6), -0.3f);
        if (Physics.BoxCast(position, new Vector3(0.5f,0.5f,0.5f), Vector3.zero))
        {
            Debug.Log("Unsafe rock spawn");
            position = NewPosition();
        }
        return position;
    }
}
