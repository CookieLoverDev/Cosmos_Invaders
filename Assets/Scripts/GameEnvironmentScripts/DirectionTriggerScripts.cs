using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTriggerScripts : MonoBehaviour
{
    private EnemyScript enemyScript;

    private void Start()
    {
        enemyScript = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyScript.ChangeDirection();
    }
}
