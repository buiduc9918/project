using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button pauseButton; // Renamed from 'pause' to 'pauseButton' for clarity
    public bool isPaused; // Renamed from 'pauseStatus' to 'isPaused' for clarity
    public Image buttonImage; // Renamed from 'source' to 'buttonImage' for clarity
    public Sprite[] buttonSprites; // Renamed from 'destination' to 'buttonSprites' for clarity

    void Start()
    {
        isPaused = false;
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(TogglePause);
    }

    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            Time.timeScale = 1f; // Resume normal time scale
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused; // Toggle pause status
    }
}
