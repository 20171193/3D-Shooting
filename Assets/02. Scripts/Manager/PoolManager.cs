using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private PooledObject prefab;

    private Stack<PooledObject> objectPool;
    public Stack<PooledObject> ObjectPool { get { return objectPool; } }

    [SerializeField]
    private int poolSize;

    private void Awake()
    {
        CreatePool();
    }

    public void CreatePool(/*int poolSize*/)
    {
        if(poolSize < 1)
        {
            Debug.Log("has not been allocated : poolSize");
            return;
        }

        //this.poolSize = poolSize;

        objectPool = new Stack<PooledObject>(poolSize);

        for(int i =0; i < poolSize; i++)
        {
            // Create pool
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            objectPool.Push(instance);
        }
    }

    public PooledObject GetPool()
    {
        // When retrieving from the pool, activate.
        if (objectPool.Count > 0)
        {
            PooledObject instance = objectPool.Pop();
            instance.gameObject.SetActive(true);
            return instance;
        }
        // Create anew when there is no remaining quantity.
        else
            return Instantiate(prefab);
    }

    public void ReturnPool(PooledObject instance)
    {
        if (objectPool.Count < poolSize)
        {
            // When returning to the pool, deactivate.
            instance.gameObject.SetActive(false);
            objectPool.Push(instance);
        }
        // Delete when the stack's capacity is fully utilized.
        else
            Destroy(instance);
    }
}
