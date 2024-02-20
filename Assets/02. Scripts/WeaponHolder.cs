using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private Gun[] guns;

    private Gun curGun;

    private void Start()
    {
        curGun = guns[0];
    }

    public void Fire()
    {
        curGun.Fire();
    }

    public void Reload()
    {

    }
}
