using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Components")]
    [Space(2)]
    [SerializeField]
    private Transform muzzlePoint;
    [SerializeField]
    private Rigidbody bulletPrefab;
    [SerializeField]
    private ParticleSystem muzzleFlash;
    [SerializeField]
    private ParticleSystem hitEffect;

    [SerializeField]
    private LineRenderer lr;

    [Space(3)]
    [Header("Specs")]
    [Space(2)]
    [SerializeField]
    private int damage;

    [Space(3)]
    [Header("Layer")]
    [Space(2)]
    [SerializeField]
    private LayerMask rayLM; 

    [Space(3)]
    [Header("Ballancing")]
    [Space(2)]
    [SerializeField]
    private float bulletPower;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private Transform hitPoint;

    public void Fire()
    {
        Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red, 0.3f);
        muzzleFlash.Play();

        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit hitInfo, maxDistance, rayLM))
        {
            IDamageable target = hitInfo.collider.GetComponent<IDamageable>();
            target?.TakeDamage(damage);

            ParticleSystem particle = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            particle.transform.parent = hitInfo.transform;

            Rigidbody rb = hitInfo.collider.GetComponent<Rigidbody>();
            if(rb != null)
                rb?.AddForceAtPosition(-hitInfo.normal * 10f, hitInfo.point, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("not Hit!");
        }
    }
}
