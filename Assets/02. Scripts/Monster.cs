using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{
    [Header("Components")]
    [Space(2)]
    [SerializeField]
    private Rigidbody rigid;

    [Space(3)]
    [Header("Specs")]
    [Space(2)]
    [SerializeField]
    private int hp;


    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
