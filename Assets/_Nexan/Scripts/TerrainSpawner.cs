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
    [SerializeField] Transform canyonSpawnLocation;

    private int terrainCounter = 1;
    private void Start()
    {

        InvokeRepeating("SpawnTerrainObjects",terrainSpawnWaitTime, terrainObjectSpawnRate);
    }

    private void SpawnTerrainObjects()
    {
       
        GameObject newCanyonUnit = PoolManager.Instance.GetPooledItemByTag("canyon");
        if(newCanyonUnit != null )
        {
            newCanyonUnit.transform.SetPositionAndRotation(new Vector3(canyonSpawnLocation.position.x,
           canyonSpawnLocation.position.y,
           canyonSpawnLocation.position.z), Quaternion.identity);
            newCanyonUnit.SetActive(true);
        }
        else
        {
            Debug.Log("no pooled item!");
        }
        
       
    }
}
