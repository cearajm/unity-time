using UnityEngine;
using UnityEngine.InputSystem;
// using UnityEngine.InputActionMap;

public class PauseMenu : MonoBehaviour
{
    // reference to menu object
    [Header("UI References")]
    [SerializeField] private GameObject pauseMenu;

    [Header("Gameplay Input")]
    // [SerializeField] private PlayerInputHandler playerInputHandler;
    
    public bool isPaused;
    private InputActionMap playerActionMap;
    private InputActionMap uiActionMap;
    private InputAction pauseAction;



    void Awake()
    {
        pauseMenu.SetActive(false);  // godot hide()
        print("hello hello. pause menu is awake");

        isPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }


    void Start()
    {
        // Get the default input maps
        playerActionMap = InputSystem.actions.FindActionMap("Player");
        uiActionMap = InputSystem.actions.FindActionMap("UI");

        pauseAction = InputSystem.actions.FindAction("Cancel");
    }


    // Update is called once per frame
    void Update()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            Debug.Log("esc pressed for real");
            Debug.Log(isPaused);
            TogglePause();
        }
    }


    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }


    public void PauseGame()
    {
        playerActionMap.Disable();  // pause movement inputs
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;  // stop in-game clock to pause (stop updates)
        isPaused = true;
    }


    public void ResumeGame()
    {
        playerActionMap.Enable();  // resume movement inputs
        pauseMenu.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Test()
    {
        print("test hi");
    }


}
