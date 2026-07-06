using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;
using System.Collections;

public class StartScreenManager : MonoBehaviour
{
    public PlayableDirector timeline;
    public GameObject cinematicCameras;
    public GameObject playerCamera;
    public Canvas startScreenCanvas;
    public Canvas gameStateCanvas;
    public Canvas mobileControlsCanvas;
    public PlayerInput playerInput;
    private bool gameStarted = false;

    public static bool skipCinematic = false;

    void Start()
    {
        playerInput.enabled = false;

        if (skipCinematic)
        {
            SkipToGameplay();
        }
    }

    void Update()
    {
        if(gameStarted || skipCinematic) return;

        bool keyboardPressed = Keyboard.current != null 
                            && Keyboard.current.anyKey.isPressed;
        bool touchScreenTapped = Touchscreen.current != null 
                            && Touchscreen.current.primaryTouch.press.isPressed;
        bool mouseClicked = Mouse.current != null
                            && Mouse.current.leftButton.isPressed;

        if(keyboardPressed || touchScreenTapped || mouseClicked)
        {
            gameStarted = true;
            StartCoroutine(StartGame());
        }
    }

    private IEnumerator StartGame()
    {
        BlackScreenFader.Instance.StartFadeAnimation();

        yield return new WaitForSeconds(1);
        
        timeline.Stop();
        cinematicCameras.SetActive(false);
        startScreenCanvas.enabled = false;

        playerCamera.SetActive(true);
        gameStateCanvas.enabled = true;
        mobileControlsCanvas.enabled = true;
        playerInput.enabled = true;
    }

    private void SkipToGameplay()
    {
        timeline.Stop();
        cinematicCameras.SetActive(false);
        startScreenCanvas.enabled = false;

        playerCamera.SetActive(true);
        gameStateCanvas.enabled = true;
        mobileControlsCanvas.enabled = true;
        playerInput.enabled = true;
    }
}
