using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPlatforms : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Spikes;
    static System.Random R = new System.Random();
    float minX = -8, maxX = 2118f, minY = -3, maxY = 4, distanceBetweenPlatforms = 5f, minWidth = 0.1f, maxWidth = 1f, minHeight = 0.1f, maxHeight = 1f;
    private void Start()
    {
        spawnPlatforms();
    }
    void spawnPlatforms()
    {
        float currX = minX;
        int i = 0;
        int j = 0;
        while (currX < maxX)
        {
            float randY = Random.Range(minY, maxY);
            float platformWidth = Random.Range(minWidth, maxWidth);
            float platformHeight = Random.Range(minHeight, maxHeight);
            Vector2 platformSize = new Vector2(platformWidth,platformHeight);
            Vector2 spawnPosition = new Vector2 (currX + (platformWidth / 2), randY);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPosition, platformSize, 0f);
            if (colliders.Length == 0 ) { 
                GameObject newPlatform = Instantiate(Platform, spawnPosition, Quaternion.identity);
                newPlatform.transform.localScale = platformSize;
                if (R.NextDouble() < .5)
                {
                    Debug.Log("spike generate" + i);
                    GameObject newSpike = Instantiate(Spikes, new Vector2(spawnPosition.x, spawnPosition.y + platformHeight), Quaternion.identity);
                    newSpike.transform.localScale = platformSize;
                    i++;
                }
                j++;
                Debug.Log("Platform generate " + j);
                
            } 
            currX += distanceBetweenPlatforms;
            Debug.Log(currX);
        }
    }
}
