sing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject coinPrefab;
    public GameObject shieldPowerUpPrefab; 

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1f, 2f);
        InvokeRepeating("CreateEnemyTwo", 3f, 5f);
        InvokeRepeating("CreateCoin", 2f, 4f);

        
        InvokeRepeating("CreateShieldPowerUp", 5f, 10f);

        UpdateScoreText();
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateCoin()
    {
        float randomX = Random.Range(-8.5f, 8.5f);
        float randomY = Random.Range(-5.5f, -0.5f); // Keeps it in the bottom half where the player can reach it
        Instantiate(coinPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
    }

    
    void CreateShieldPowerUp()
    {
        float randomX = Random.Range(-8.5f, 8.5f);
        Instantiate(shieldPowerUpPrefab, new Vector3(randomX, 6.5f, 0), Quaternion.identity);
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
