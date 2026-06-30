using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitMotion.Animation;

public class BlackScreenFader : MonoBehaviour
{
    public static BlackScreenFader Instance;

    private LitMotionAnimation fadeAnimation;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        fadeAnimation = GetComponent<LitMotionAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFadeAnimation()
    {
        fadeAnimation.Restart();
    }
}
