using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    // reference to menu object
    public GameObject pauseMenu;
    public bool isPaused;

    // [Header("References")]
    // [SerializeField] private PlayerInputHandler playerInputHandler;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);  // godot hide()
        print("hello hello");
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Escape))
        // if(playerInputHandler.PauseTriggered)
        // {
        //     if(isPaused)
        //     {
        //         ResumeGame();
        //     }
        //     else
        //     {
        //         PauseGame();
        //     }
        // }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;  // stop in-game clock to pause (stop updates)
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

}
