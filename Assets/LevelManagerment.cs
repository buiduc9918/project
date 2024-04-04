using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;

    public string World1;
    public string World2;
    public string World3;

    void Start()
    {

        level1.onClick.AddListener(Level1);
        level2.onClick.AddListener(Level2);
        level3.onClick.AddListener(Level3);
    }

    public void Level1() => SceneManager.LoadScene(World1);
    public void Level2() => SceneManager.LoadScene(World2);
    public void Level3() => SceneManager.LoadScene(World3);
}
