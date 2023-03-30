using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> poolable;

    [SerializeField] private int poolSize = 20;

    [SerializeField] private GameObject objectToPool;

    public static ObjectPool SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        poolable = new List<GameObject>();
        GameObject tmp;
        
        for(int i = 0; i < poolSize; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            poolable.Add(tmp);
        }
       
    }

    public GameObject GetObject()
    {
        for(int i = 0; i < poolSize; i++)
        {
            if (!poolable[i].activeInHierarchy)
            {
                return poolable[i];
            }
        }
        return null;
    }

    


}
