using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    #region 싱글턴 메서드
    private static GameManager instance = null;
    [SerializeField] 
    private LayerManager layerManager;
    [SerializeField]
    private PoolManager poolManager;

    public static LayerManager Layer { get { return instance.layerManager; } }
    public static PoolManager Pool { get { return instance.poolManager; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //this.sceneInfo = instance.sceneInfo;
            Destroy(this.gameObject);
        }
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                return null;
            else
                return instance;
        }
    }
    #endregion
}
