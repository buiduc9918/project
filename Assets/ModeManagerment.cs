using UnityEngine;
using UnityEngine.UI;

public class ModeManagement : MonoBehaviour
{
    public Button simple;
    public Button easy;
    public Button hard;

    public float speed;
    public float hardModeSpeed = 1f;
    public float easyModeSpeed = 1.3f;
    public float simpleModeSpeed = 1.7f;

    void Start()
    {
        simple.onClick.AddListener(SimpleMode);
        easy.onClick.AddListener(EasyMode);
        hard.onClick.AddListener(HardMode);
    }

    public void HardMode() => speed = hardModeSpeed;
    public void SimpleMode() => speed = simpleModeSpeed;
    public void EasyMode() => speed = easyModeSpeed;
}
