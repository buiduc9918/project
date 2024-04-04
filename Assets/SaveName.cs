using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public string PlayerName;
    public TMP_InputField InputField;
    public TextMeshProUGUI score;
    public Button Button;

    void Start()
    {
        Button = GetComponent<Button>();

        // Remove any existing listeners to prevent duplicate listeners

        // Add a listener to call savename() when the button is clicked
        Button.onClick.AddListener(savename);

        InputField = GetComponent<TMP_InputField>();

        // Check if GameManager.Instance is not null and lives is zero

    }

    public void savename()
    {
        PlayerName = InputField.text;

        // Check if GameManager.Instance is not null before accessing its properties/methods
        if (Gamemanager.Instance != null)
        {
            Gamemanager.Instance.namePlayer = PlayerName;
        }
    }
}
