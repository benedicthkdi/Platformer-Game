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

    void Start()
    {
        playerInput.enabled = false;
    }

    void Update()
    {
        if(gameStarted) return;

        bool keyboardPressed = Keyboard.current != null 
                            && Keyboard.current.anyKey.wasPressedThisFrame;
        bool touchScreenTapped = Touchscreen.current != null 
                            && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;
        bool mouseClicked = Mouse.current != null
                            && Mouse.current.leftButton.wasPressedThisFrame;

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
}
