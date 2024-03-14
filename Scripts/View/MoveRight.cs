using System;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public static MoveRight Instance;

    private BirdController birdController;
    public float speed = 8f;
    private void Awake()
    {
        birdController = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdController>();
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void Moveright()
    {
        try
        {
            if (birdController.fly)
            {
                transform.Translate(Vector2.left * Time.deltaTime * UnityEngine.Random.Range(6f, 13f));
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector2.left * Time.deltaTime * UnityEngine.Random.Range(5f, 18f));
            }

        }
    }
}
