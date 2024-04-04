using UnityEngine;
using UnityEngine.UI;

public class InfomationManager : MonoBehaviour
{
    public Button infomation;
    public bool infomationStatus;
    public Sprite[] destination;
    public GameObject[] gameObjects;
    void Start()
    {
        infomationStatus = false;
        infomation = GetComponent<Button>();
        infomation.onClick.AddListener(InfomationController);
    }

    // Update is called once per frame
    void Update()
    {
        if (infomationStatus == false)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }

        }
        if (infomationStatus == true)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }

        }
    }

    public void InfomationController()
    {
        infomationStatus = !infomationStatus;
    }
}
