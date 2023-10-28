using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Text currentScore;
    public Text lives;
    public GameObject deathScreen;
    public GameObject winScreen;
    public DamageScript player;

    private int currentScoreInt = 0;
    public bool gameActive = true;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageScript>();
    }

    private void Update()
    {
        lives.text = $"{player.health}";
    }
    public void AddScore()
    {
        currentScoreInt += 5;
        currentScore.text = $"{currentScoreInt}";
    }

    public void GameOver()
    {
        gameActive = false;
        deathScreen.SetActive(true);
    }

    public void GameWon()
    {
        gameActive = false;
        winScreen.SetActive(true);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
