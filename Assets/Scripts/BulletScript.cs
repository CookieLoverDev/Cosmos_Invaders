using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletSpeed = 20.0f;
    [SerializeField] private Rigidbody2D rb;
    private int damage = 1;
    void Start()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageScript enemy = collision.gameObject.GetComponent<DamageScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else
        {
            Debug.Log("DamegeScript not found on the object");
        }
        Destroy(gameObject);
    }
}
