using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int lives = 3;

    void Awake()
    {
        Instance = this;
    }

    public void LoseLife()
    {
        lives--;

        HealthUIManager.Instance.UpdateHearts(lives);

        if (lives <= 0)
        {
            HealthUIManager.Instance.ShowGameOver();
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

