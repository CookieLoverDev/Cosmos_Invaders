using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
    public GameObject enemyBulletPrefab;

    public void EnemyShoot(GameObject enemyObject)
    {
        Instantiate(enemyBulletPrefab, enemyObject.transform.position, enemyObject.transform.rotation);
    }
}
