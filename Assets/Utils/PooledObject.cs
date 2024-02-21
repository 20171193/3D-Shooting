using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPooler pooler;

    [SerializeField]
    private bool autoRelease;

    private Coroutine releaseRoutine;

    private void OnEnable()
    {
        if(autoRelease)
            releaseRoutine = StartCoroutine(ReturnPool());
    }
    private void OnDisable()
    {
        if(autoRelease)
            StopCoroutine(releaseRoutine);
    }

    public void Release()
    {
        Debug.Log("owner pool is null");
        Destroy(this.gameObject);
        return;
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
