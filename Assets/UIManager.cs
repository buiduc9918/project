using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button UI;
    public bool UIStatus;
    public GameObject[] gameObjects;
    void Start()
    {
        UIStatus = false;
        UI = GetComponent<Button>();
        UI.onClick.AddListener(UIController);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIStatus == false)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }

        }
        if (UIStatus == true)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }

        }
    }

    public void UIController()
    {
        UIStatus = !UIStatus;
    }
}
