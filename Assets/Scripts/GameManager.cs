using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int lives = 3;

    public GameObject gameOverScreen;

    void Start()
    {
      Instance = this;  
    }

    public void LoseLife()
    {
        lives--;

        HealthUIManager.Instance.UpdateHearts(lives);

        if(lives == 0)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            RespawnManager.Instance.StartRespawn();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
