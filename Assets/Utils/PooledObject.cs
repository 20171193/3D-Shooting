using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ReturnPool());
    }
    public void Release()
    {
        GameManager.Pool.ReturnPool(this);
    }
    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(2.0f);
        Release();
    }
}
