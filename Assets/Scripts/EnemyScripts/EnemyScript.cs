using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;

    private int rows = 3;
    private int cols = 12;
    private float enemySpacing = 5.0f;
    private float enemySpeed = 2.0f;
    private float movementInterval = 1.0f;
    private float attackInterval = 1.25f;
    private int enemyWaves = 0;

    public EnemyWeaponScript enemyWeapon;
    private GameLogic gameLogic;

    public List<GameObject> enemyList = new List<GameObject>();
    private bool moveRight = true;


    private void Start()
    {
        enemyWeapon = enemyPrefab.GetComponent<EnemyWeaponScript>();
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();

        for (int i=0; i<rows; i++)
        {
            for (int j=0; j<cols; j++)
            {
                Vector3 spawnPos = spawnPoint.position + new Vector3(j*enemySpacing, i*enemySpacing, 0);
                GameObject enemy =  Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                enemyList.Add(enemy);
            }
        }

        InvokeRepeating("EnemyMovement", 0f, movementInterval);
        InvokeRepeating("EnemyAttack", 1f, attackInterval);
    }

    void Update()
    {
        if (!gameLogic.gameActive)
        {
            CancelInvoke("EnemyMovement");
            CancelInvoke("EnemyAttack");

            movementInterval -= 0.25f;
            attackInterval -= 0.25f;
        }

        if (!enemyList.Any() && enemyWaves <= 2)
        {
            CancelInvoke("EnemyMovement");
            CancelInvoke("EnemyAttack");

            Start();
            moveRight = true;
            enemyWaves++;
        }
        else if (enemyWaves > 2)
        {
            foreach (GameObject enemy in enemyList)
            {
                Destroy(enemy);
            }
            gameLogic.GameWon();
        }
    }

    void EnemyMovement()
    {
        foreach (GameObject enemy in enemyList)
        {
            enemy.transform.Translate(moveRight ? Vector3.right * enemySpeed  : Vector3.left * enemySpeed);
        }
    }

    public void ChangeDirection()
    {
        moveRight = !moveRight;
        foreach (GameObject enemy in enemyList)
        {
            enemy.transform.Translate(Vector3.down * enemySpeed);
            if (moveRight)
            {
                enemy.transform.Translate(Vector3.right * enemySpeed);
            }
            else
            {
                enemy.transform.Translate(Vector3.left * enemySpeed);
            }

        }
    }

    void EnemyAttack()
    {
        if (enemyWeapon)
        {
            if(enemyList.Count >= 5)
            {
                for (int i = 0; i <= 6; i++)
                {
                    int randomEnemy = Random.Range(0, enemyList.Count);
                    enemyWeapon.EnemyShoot(enemyList[randomEnemy]);
                }
            }
            else
            {
                for (int i = 0; i < enemyList.Count; i++)
                {
                    enemyWeapon.EnemyShoot(enemyList[i]);
                }
            }
            
        }
        else
        {
            Debug.Log("No enemy weapon");
        }
    }
}
