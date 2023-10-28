using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEndPointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LaserBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
