using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance { get; private set; }
    public int score;
    public int NumberBird;
    [SerializeField] public int lives { get; private set; }
    public List<string> highScore { get; private set; }
    public string filename;
    public string startWorld = "1";
    public string world;
    public string namePlayer;

    public void Awake()
    {
        if (Instance != null) DestroyImmediate(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    public void AddList(int score, string nameplayer)
    {
        if (highScore == null)
            highScore = new List<string>();

        string entry = nameplayer + " : " + score.ToString() + " : " + lives.ToString();
        highScore.Add(entry);
        SortScores(highScore);
        SaveScores(highScore);
    }

    private void SaveScores(List<string> scores)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (string score in scores)
            {
                sw.WriteLine(score);
            }
        }
    }

    public List<string> LoadListFromFile()
    {
        List<string> list = new List<string>();
        if (File.Exists(filename))
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }
            }
        }
        return list;
    }

    private void SortScores(List<string> scores) => scores.Sort((a, b) => stringtoint(b).CompareTo(stringtoint(a)));

    private int stringtoint(string player)
    {
        string[] parts = player.Trim().Split(":");
        int score = 0;
        if (parts.Length > 1) int.TryParse(parts[1].Trim(), out score);
        return score;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        NewGame();
    }

    public void NewGame()
    {
        lives = 3;
        score = 0;
        LoadLevel(startWorld);
    }

    public void GameOver()
    {
        AddList(score, namePlayer);
        NewGame();
    }

    public void LoadLevel(string world)
    {
        this.world = world;
        SceneManager.LoadScene(world);
    }

    public void NextLevel()
    {
        int nextgame = 0;
        int.TryParse(world, out nextgame);
        nextgame = nextgame + 1;
        if (nextgame == 4) nextgame = 1;
        string nextworld = nextgame.ToString();
        LoadLevel(nextworld);
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0) LoadLevel(startWorld);
        else GameOver();
    }

    public void AddScore()
    {
        score++;
        if (score == 100)
        {
            score = 0;
            AddLife();
        }

        if (score == 10)
        {
            score = 10;
            NextLevel();
        }

        if (score == 20)
        {
            score = 20;
            NextLevel();
        }

        if (score == 30)
        {
            score = 0;
            NextLevel();
        }
    }

    public void AddLife()
    {
        lives++;
    }
}
