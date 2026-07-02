using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour
{
    public static HealthUIManager Instance;

    public Image[] hearts;

    public Sprite redHeart;
    public Sprite grayHeart;

    void Start()
    {
        Instance = this;    
    }

    public void UpdateHearts(int livesRemaining)
    {
        if(livesRemaining == 0)
        {
            hearts[0].sprite = grayHeart;
            hearts[1].sprite = grayHeart;
            hearts[2].sprite = grayHeart;
        }
        else if(livesRemaining == 1)
        {
            hearts[0].sprite = redHeart;
            hearts[1].sprite = grayHeart;
            hearts[2].sprite = grayHeart;
        }
        else if(livesRemaining == 2)
        {
            hearts[0].sprite = redHeart;
            hearts[1].sprite = redHeart;
            hearts[2].sprite = grayHeart;
        }
        else if(livesRemaining == 3)
        {
            hearts[0].sprite = redHeart;
            hearts[1].sprite = redHeart;
            hearts[2].sprite = redHeart;
        }
    }
}
