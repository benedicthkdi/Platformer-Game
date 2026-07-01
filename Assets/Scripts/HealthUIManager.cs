using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour
{
    public static HealthUIManager Instance;

    public Image[] hearts;
    public Sprite redHeart;
    public Sprite grayHeart;

    public GameObject gameOverScreen; 

    void Awake()
    {
        Instance = this;
    }

    public void UpdateHearts(int livesRemaining)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < livesRemaining)
            {
                hearts[i].sprite = redHeart;
            }
            else
            {
                hearts[i].sprite = grayHeart;
            }
        }
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
