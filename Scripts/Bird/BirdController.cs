using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public static BirdController Instance;
    public GameObject player;
    public GameObject birdBlue;
    public GameObject birdRed;
    public GameObject birdYellow;
    public GameObject banner;
    public GameObject button;
    public Button butTon;
    private int birdNumber = 0;
    public GameObject gameOver;
    private BirdMoverment birdMoverment;
    public bool dead = false;
    public bool fly;
    public int score;
    public bool buff;
    public TextMeshProUGUI scoreText;
    private Up up;
    private MoveRight moveRight;
    public TMP_InputField inputField;
    public GameObject tmp_field;
    public TextMeshProUGUI nameText;
    public GameObject nametext;
    public string namePlayer = "player";
    public BirdAnimation birdAnimation;
    public ScoreManager scoreManager;
    public TextMeshProUGUI s1;
    public TextMeshProUGUI s2;
    public TextMeshProUGUI s3;
    public int world = 3;
    private void Awake()
    {
        fly = false;
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        birdAnimation = GetComponent<BirdAnimation>();
        moveRight = GameObject.FindObjectOfType<MoveRight>().GetComponent<MoveRight>();
        try
        {
            up = GameObject.FindGameObjectWithTag("Special Pipe").GetComponent<Up>();
        }
        catch (Exception E)
        {
            Debug.Log(E.Message + " Bạn phải đợi xuất hiện pipes à star ");
        }
        fly = false;
        butTon = button.GetComponent<Button>();
        birdMoverment = GetComponent<BirdMoverment>();

    }
    private void Start()
    {
        showhighscores();
        buff = false;
        score = 0;
        button.SetActive(true);
        banner.SetActive(true);
        gameOver.SetActive(false);
        tmp_field.SetActive(true);
        nametext.SetActive(true);
        Chuyen(birdNumber);
        birdMoverment.OnDisable();
        butTon.onClick.AddListener(StartGame);
    }
    private void Update()
    {
        try
        {
            up.MoveUp();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message + " Waiting sẽ có thôi ");
        }

        moveRight.Moveright();
        if (Input.GetKeyDown(KeyCode.K))
        {
            birdNumber++;
            birdNumber %= 3;
            Chuyen(birdNumber);
        }
        if (player.transform.position.y < -5 || player.transform.position.y > 6)
        {
            OverGame();
        }
        birdAnimation.Change();
    }
    public void OnclickField()
    {
        if (inputField.text.Trim() != null)
        {
            namePlayer = inputField.text;
        }
        nameText.text = namePlayer;
        nametext.SetActive(true);
        tmp_field.SetActive(false);
    }
    public void StartGame()
    {
        name = inputField.text;
        nameText.text = name;
        nametext.SetActive(true);
        tmp_field.SetActive(false);
        button.SetActive(false);
        banner.SetActive(false);
        scoreText.gameObject.SetActive(true);
        fly = true;
        birdMoverment.OnEnable();
    }

    public void OverGame()
    {
        Destroy(gameObject);
        gameOver.SetActive(true);
        banner.SetActive(true);
        button.SetActive(true);
        dead = true;
        fly = false;
        scoreManager.AddList(score, namePlayer);
        try
        {
            birdMoverment.BirdDead(dead);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message + "Bạn phải quay lại thế giới gốc");
            SceneManager.LoadScene(world.ToString());
        }
    }
    private void Chuyen(int birdNumber)
    {
        if (birdNumber == 0)
        {
            birdBlue.SetActive(true);
            birdRed.SetActive(false);
            birdYellow.SetActive(false);
        }
        if (birdNumber == 1)
        {
            birdBlue.SetActive(false);
            birdRed.SetActive(true);
            birdYellow.SetActive(false);
        }
        if (birdNumber == 2)
        {
            birdBlue.SetActive(false);
            birdRed.SetActive(false);
            birdYellow.SetActive(true);
        }
    }
    public void addscore(int add)
    {
        score += add;
        scoreText.text = "Score: " + score.ToString();
    }
    private void showhighscores()
    {
        List<string> strings = scoreManager.LoadListFromFile();
        try
        {
            s1.text = strings[0];
        }
        catch (Exception e)
        {
            s1.text = "player : 40";
        }
        try
        {
            s2.text = strings[1];
        }
        catch (Exception e)
        {
            s2.text = "player : 40";
        }
        try
        {
            s3.text = strings[2];
        }
        catch (Exception e)
        {
            s3.text = "player : 40";
        }
    }
}