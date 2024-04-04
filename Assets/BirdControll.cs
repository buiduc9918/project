using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BirdControll : MonoBehaviour
{
    public string nameplay;
    public Button time;     //gam paubutton
    public TMP_InputField namein;
    public Button startgame;        // gan move buttom
    public TextMeshProUGUI Score;
    private Movement Movement;

    private void Start()
    {
        time = GetComponent<Button>();
        time.onClick.AddListener(aftersavename);
        startgame = GetComponent<Button>();
        startgame.onClick.AddListener(showScore);
        Movement = GetComponent<Movement>();
        showScore();
    }

    private void Update()
    {
        Score.text = Gamemanager.Instance.score.ToString();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Special Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            Score.text = "GameOver";
            name = namein.text;
            Gamemanager.Instance.namePlayer = name;
            Gamemanager.Instance.ResetLevel();
            Gamemanager.Instance.ResetLevel();
        }

    }
    public void aftersavename()
    {


    }
    public void showScore()
    {

    }
}

