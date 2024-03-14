using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class spri : MonoBehaviour
{
    public Button s1;
    public Button s2;
    public Button s3;

    // Start is called before the first frame update
    void Start()
    {
        s1.onClick.AddListener(tgmattroi);
        s2.onClick.AddListener(tgmattrang);
        s1.onClick.AddListener(td);
    }

    public void tgmattrang()
    {
        SceneManager.LoadScene("2");
    }
    public void tgmattroi()
    {
        SceneManager.LoadScene("1");
    }
    public void td()
    {
        SceneManager.LoadScene("3");
    }

}
