using UnityEngine;
using UnityEngine.UI;

public class SetupManagement : MonoBehaviour
{
    public Button setupButton;
    public bool setupStatus;
    public Image source;
    public Sprite[] destination;
    public GameObject[] gameObjects;

    void Start()
    {
        setupStatus = false;
        source = setupButton.GetComponent<Image>();
        setupButton = GetComponent<Button>();
        setupButton.onClick.AddListener(ToggleSetup);
    }

    void Update()
    {
        UpdateSetupStatus();
        UpdateGameObjectVisibility();
    }

    void UpdateSetupStatus()
    {
        if (setupStatus)
        {
            source.sprite = destination[0];
        }
        else
        {
            source.sprite = destination[1];
        }
    }

    void UpdateGameObjectVisibility()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(setupStatus);
        }
    }

    public void ToggleSetup()
    {
        setupStatus = !setupStatus;
    }
}
