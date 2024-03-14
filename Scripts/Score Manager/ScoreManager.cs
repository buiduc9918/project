using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public List<string> highscores { get; private set; }
    public string filename = "data.txt";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        highscores = LoadListFromFile();
        SortScores(highscores);
    }

    public void AddList(int score, string nameplayer)
    {
        string entry = nameplayer + " : " + score.ToString();
        highscores.Add(entry);
        SortScores(highscores);
        SaveScores(highscores);
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

    private void SortScores(List<string> scores)
    {
        scores.Sort((a, b) => stringtoint(b).CompareTo(stringtoint(a)));
    }

    private int stringtoint(string player)
    {
        string[] parts = player.Trim().Split(":");
        int score = 0;
        if (parts.Length > 1)
        {
            int.TryParse(parts[1], out score);
        }
        return score;
    }


}
