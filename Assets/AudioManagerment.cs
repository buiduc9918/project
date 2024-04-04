using UnityEngine;
using UnityEngine.UI;

public class AudioManagerment : MonoBehaviour
{
    public Button audioButton;
    public bool audioStatus;
    public Image buttonImage;
    public Sprite[] buttonSprites;
    public AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        audioStatus = true; // Assume audio is initially enabled
        audioButton = GetComponent<Button>();
        audioButton.onClick.AddListener(ToggleAudio);
        // Assign AudioSource component from the current GameObject or its children
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        // Check if audioSource is not null to avoid null reference exceptions
        if (audioSource != null)
        {
            // Set the audio status based on the AudioSource's mute property
            audioStatus = !audioSource.mute;
        }

        // Update button appearance based on audioStatus
        buttonImage.sprite = audioStatus ? buttonSprites[0] : buttonSprites[1];
    }

    public void ToggleAudio()
    {
        // Toggle audioStatus
        audioStatus = !audioStatus;

        // Toggle mute property of the AudioSource based on audioStatus
        if (audioSource != null)
        {
            audioSource.mute = !audioStatus;
        }
    }
}
