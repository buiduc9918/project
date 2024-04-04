using UnityEngine;
using UnityEngine.UI;

public class BirdManager : MonoBehaviour
{
    public Button button;
    public GameObject[] birds;
    private int currentIndex = 0;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChooseBird);
    }

    public void ChooseBird()
    {
        currentIndex = (currentIndex + 1) % birds.Length;
        for (int i = 0; i < birds.Length; i++)
        {
            birds[i].SetActive(i == currentIndex);
        }
        Gamemanager.Instance.NumberBird = currentIndex;
    }

}
