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
        GameManager.Pool.CreatePool("�Ѿ�", bulletPrefab, 20);
        GameManager.Pool.CreatePool("����Ʈ", effectPrefab, 10);
    }
    private void UnLoading()
    {
        GameManager.Pool.RemovePool("�Ѿ�");
        GameManager.Pool.RemovePool("����Ʈ");
    }
}
