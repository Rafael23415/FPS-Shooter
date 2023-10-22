using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject settings;

    [Header("UI")]
    public GameObject playerUI;

    [Header("Buttons")]
    public Buttons resumeButton;
    public Buttons returnButton;

    [HideInInspector]
    public bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || resumeButton.resumeCount == 1)
        {
            TogglePaused();
            resumeButton.resumeCount = 0;
        }

    }

    void TogglePaused()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            settings.SetActive(false);
            GetComponentInParent<MouseLook>().enabled = false;
            playerUI.gameObject.SetActive(false);
        }
        else if(!isPaused)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
            GetComponentInParent<MouseLook>().enabled = true;
            playerUI.gameObject.SetActive(true);
        }
    }
}
