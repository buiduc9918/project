using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private BirdController birdController;

    private void Awake()
    {
        birdController = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            birdController.addscore(1);
        }
    }
}
