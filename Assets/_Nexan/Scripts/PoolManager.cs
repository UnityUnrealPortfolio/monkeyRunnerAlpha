using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    public List<PoolItem> itemsToBePooled;
    [SerializeField] List<GameObject> pooledItems;

    private void Awake()
    {
        Instance = this;   
    }

    private void Start()
    {
        foreach (var item in itemsToBePooled)
        {
            for (int i = 0; i < item.m_amount; i++)
            {
                var newPoolItem = Instantiate(item.m_prefab);
                newPoolItem.transform.SetParent(transform, false);
                newPoolItem.SetActive(false);
                pooledItems.Add(newPoolItem);
            }
        }
    }

    //method to return a pooled item based on it's tag
    public GameObject GetPooledItemByTag(string _tag)
    {
        //loop through all items that have been pooled
        for(int i = 0; i < pooledItems.Count; i++)
        {
            //check if we have a pooled item with the passed in tag inactive in heirarchy
            //if so return the pooled item
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == _tag)
            {
                return pooledItems[i];
            }
        }
        return null;
    }
}


[System.Serializable]   
public class PoolItem
{
    public GameObject m_prefab;
    public int m_amount;
}
