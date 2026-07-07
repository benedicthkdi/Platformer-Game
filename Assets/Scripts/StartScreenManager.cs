using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class StartScreenManager : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject animationCameras;
    public Canvas mobileControlsCanvas;
    public Canvas gameStateCanvas;
    public Canvas startScreenCanvas;
    public PlayerInput playerInput;
    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        playerInput.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted == false)
        {
            bool keyboardPress = Keyboard.current != null && 
                        Keyboard.current.anyKey.isPressed;
            bool mouseClick = Mouse.current != null && 
                        Mouse.current.leftButton.isPressed;
            bool touchScreenTap = Touchscreen.current != null && 
                        Touchscreen.current.primaryTouch.press.isPressed;

            if(keyboardPress == true || mouseClick == true || touchScreenTap == true)
            {
                gameStarted = true;
                StartCoroutine(StartGame());
            }
        }
    }

    public IEnumerator StartGame()
    {
        BlackScreenFader.Instance.StartFadeAnimation();
        
        yield return new WaitForSeconds(1);

        timeline.Stop();
        animationCameras.SetActive(false);

        startScreenCanvas.enabled = false;
        mobileControlsCanvas.enabled = true;
        gameStateCanvas.enabled = true;
        playerInput.enabled = true;
    }
}
