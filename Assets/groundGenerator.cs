using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundGenerator : MonoBehaviour
{
    public GameObject ground;
    public GameObject background;
    public float distanceBetweenPlatforms = 15f;
    public float distanceBetweenBG = 25f;
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
        Vector3 backSpawn = new Vector3(transform.position.x, 0, 0);
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            GameObject newPlatform = Instantiate(ground, new Vector3(spawnPosition.x, -5, 0), Quaternion.identity);
            GameObject newBackgroundhigher = Instantiate(background, new Vector3(backSpawn.x, backSpawn.y + 12, 0), Quaternion.identity);
            GameObject newBackground = Instantiate(background, backSpawn, Quaternion.identity);
            spawnPosition += new Vector3(distanceBetweenPlatforms, 0f, 0f);
            backSpawn += new Vector3(distanceBetweenBG, 0, 0);
        }
        
    }
}
