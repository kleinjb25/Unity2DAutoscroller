using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundGenerator : MonoBehaviour
{
    public GameObject ground;
    public float distanceBetweenPlatforms = 10f;
    public int numberOfPlatforms = 5;
    // Start is called before the first frame update
    void Start()
    {
        extendGround();
    }

    // Update is called once per frame
    void extendGround()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, 0, 0);
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            GameObject newPlatform = Instantiate(ground, new Vector3(spawnPosition.x, -4, 0), Quaternion.identity);
            spawnPosition += new Vector3(distanceBetweenPlatforms, 0f, 0f);
        }
        
    }
}
