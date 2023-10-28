using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private float bulletSpeed = 20.0f;
    [SerializeField] private Rigidbody2D rb;
    private int damage = 1;
    void Start()
    {
        rb.velocity = -transform.up * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageScript enemy = collision.gameObject.GetComponent<DamageScript>();
        if (enemy != null)
        {
            if (collision.tag == "Enemy")
            {

            }
            else
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
            
        }
    }
}
