using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTester : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //PooledObject instance = GameManager.Pool.GetPool();
            //instance.transform.position = Random.insideUnitSphere * 10;
        }
    }
}
