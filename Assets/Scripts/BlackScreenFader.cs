using UnityEngine;
using LitMotion.Animation;

public class BlackScreenFader : MonoBehaviour
{
    public static BlackScreenFader Instance;

    private LitMotionAnimation fadeAnimation;

    void Awake()
    {
        Instance = this;
        fadeAnimation = GetComponent<LitMotionAnimation>();
    }

    public void StartFadeAnim()
    {
        fadeAnimation.Restart();
    }
}