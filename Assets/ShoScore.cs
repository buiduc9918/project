using TMPro;
using UnityEngine;

public class ShoScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreview;
    // Start is called before the first frame update
    public void showScore()
    {
        scoreview.text = Gamemanager.Instance.score.ToString();
    }
    // Update is called once per frame
}
