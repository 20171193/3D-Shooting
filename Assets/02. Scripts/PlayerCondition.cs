using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [SerializeField]
    private float maxHp;
    public float MaxHp { get { return ownHp; } }

    [SerializeField]
    private float ownHp;
    public float OwnHp { get { return ownHp; } set { ownHp = value; } }



}
