using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPlatforms : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Spikes;
    float minX = -8, maxX = 2118f, minY = -3, maxY = 4, distanceBetweenPlatforms = 2f, minWidth = 0.1f, maxWidth = 2f, minHeight = 0.1f, maxHeight = 2f;
    private void Start()
    {
        spawnPlatforms();
    }
    void spawnPlatforms()
    {
        float currX = minX;
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
                if (Random.Range(0, 1) < 0.5)
                {
                    GameObject newSpike = Instantiate(Spikes, new Vector2(spawnPosition.x, spawnPosition.y + platformHeight), Quaternion.identity);
                    newSpike.transform.localScale = platformSize;
                }
                
            } 
            currX += distanceBetweenPlatforms;
            Debug.Log(currX);
        }
    }
}