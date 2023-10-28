using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int health;
    [SerializeField] private GameObject DeathEffectPrefab;
    [SerializeField] private GameObject DeathSFXPrefab;
    public GameObject playerSFX;
    public AudioSource DeathSFX;
    private EnemyScript enemyScript;
    public GameLogic gameLogic;

    void Start()
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
        DeathSFX = GameObject.FindGameObjectWithTag("DeathSFX").GetComponent<AudioSource>();
        enemyScript = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyScript>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                DeathSFX.Play();
                Instantiate(DeathEffectPrefab, transform.position, transform.rotation);
                enemyScript.enemyList.Remove(gameObject);
                gameLogic.AddScore();
            }

            if (gameObject.tag == "Player")
            {
                Instantiate(playerSFX, transform.position, transform.rotation);
                gameLogic.GameOver();
            }

            Destroy(gameObject);
        }
    }
}
