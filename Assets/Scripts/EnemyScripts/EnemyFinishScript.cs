using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinishScript : MonoBehaviour
{
    private GameLogic gameLogic;

    void Start()
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameLogic && collision.gameObject.tag == "Enemy")
        {
            gameLogic.GameOver();
        }
    }
}
