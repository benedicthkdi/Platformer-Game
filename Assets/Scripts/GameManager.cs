using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int lives = 3;

    public GameObject gameOverScreen;
    public GameObject gameWinScreen;

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

    public void WinGame()
    {
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        playerInput.enabled = false;

        gameWinScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
