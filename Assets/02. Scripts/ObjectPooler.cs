using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private Stack<PooledObject> objectPool;
    private PooledObject prefab;
    private int size;

    public void CreatePool(PooledObject prefab, int size)
    {
        objectPool = new Stack<PooledObject>(size);
        this.prefab = prefab;
        this.size = size;

        for(int i =0; i< size; i++)
        {
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            instance.pooler = this;
            instance.transform.parent = transform;
            objectPool.Push(instance);
        }
    }
    //public PooledObject GetPool(Vector3 position, Quaternion rotation)
    //{
    //    if (objectPool.Count>0)
    //    {
    //        PooledObject instance = objectPool.Pop();
    //        instance.transform.position = position;
    //        instance.transform.rotation = rotation;
            
    //    }
    //}
    public void ReturnPool(PooledObject instance)
    {
        
        // When returning to the pool, deactivate.
        instance.gameObject.SetActive(false);
        objectPool.Push(instance);
    }
}
