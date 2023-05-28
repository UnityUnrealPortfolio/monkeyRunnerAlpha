using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    //generate terrain objects ahead of player 
    [SerializeField] Transform startingTerrainObject;
    [SerializeField] float terrainObjectSpawnRate;
    [SerializeField] float terrainSpawnWaitTime;
    [SerializeField] GameObject[] terrainPrefabObject;

    private int terrainCounter = 0;
    private void Start()
    {
        InvokeRepeating("SpawnTerrainObjects",terrainSpawnWaitTime, terrainObjectSpawnRate);
    }

    private void SpawnTerrainObjects()
    {
        int randomObject = Random.Range(0,terrainPrefabObject.Length);
        Instantiate(terrainPrefabObject[randomObject], new Vector3(startingTerrainObject.position.x,
            startingTerrainObject.position.y,
            startingTerrainObject.position.z + (terrainCounter * 200f)),
            Quaternion.identity);

        terrainCounter++;
    }
}
