using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameSceneFlow : MonoBehaviour
{
    [SerializeField]
    private PooledObject bulletPrefab;
    [SerializeField]
    private PooledObject effectPrefab;

    private void OnEnable()
    {
        Loading();
    }
    private void OnDisable()
    {
        UnLoading();
    }

    private void Loading()
    {
        GameManager.Pool.CreatePool("√—æÀ", bulletPrefab, 20);
        GameManager.Pool.CreatePool("¿Ã∆Â∆Æ", effectPrefab, 10);
    }
    private void UnLoading()
    {
        GameManager.Pool.RemovePool("√—æÀ");
        GameManager.Pool.RemovePool("¿Ã∆Â∆Æ");
    }
}
