using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private Dictionary<string, ObjectPooler> poolDic = new Dictionary<string, ObjectPooler>();

    public void CreatePool(string name, PooledObject prefab, int size)
    {
        GameObject poolObject = new GameObject($"Pool_{name}");
        ObjectPooler pooler = poolObject.AddComponent<ObjectPooler>();
        pooler.CreatePool(prefab, size);

        poolDic.Add(name, pooler);
    }
    public void RemovePool(string name)
    {
        if(!poolDic.ContainsKey(name))
        {
            Debug.Log($"error remove pool : can't find {name}");
            return;
        }

        poolDic.Remove(name);
    }

    public PooledObject GetPool(string name, Vector3 position, Quaternion rotation)
    {
        if (!poolDic.ContainsKey(name))
        {
            Debug.Log($"error Get pool : can't find {name}");
            return null;
        }

        return poolDic[name].GetPool(position, rotation);
    }
}
