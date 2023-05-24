using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class PoolItem 
{

    public int poolSize = 20;

    public GameObject objectToPool;

}


public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> poolable;
    [SerializeField] private List<PoolItem> poolObjects;



    public static ObjectPool SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        poolable = new List<GameObject>();
        foreach (PoolItem item in poolObjects)
        {
            for (int i = 0; i < item.poolSize; i++)
            {
                GameObject tmp = Instantiate(item.objectToPool);
                tmp.SetActive(false);
                poolable.Add(tmp);
            }
        }
       
    }

    public GameObject GetObject(string objectname)
    {
        for(int i = 0; i < poolable.Count; i++)
        {
            if (!poolable[i].activeInHierarchy && poolable[i].tag == objectname)
            {
                return poolable[i];
            }
        }

        foreach(PoolItem item in poolObjects)
        {
            if (item.objectToPool.tag == objectname)
            {
                GameObject temp = Instantiate(item.objectToPool);
                temp.SetActive(false);
                poolable.Add(temp);
                return temp;
            }
        }

        return null;
    }

    


}
