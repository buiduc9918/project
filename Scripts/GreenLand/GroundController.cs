using UnityEngine;

public class GroundController : MonoBehaviour
{
    private BirdController birdController;

    private void Awake()
    {
        birdController = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bird") && birdController.buff == false)
        {
            birdController.OverGame();
        }
        else if (other.gameObject.CompareTag("Bird") && birdController.buff == true)
        {
            birdController.addscore(2);
        }
    }
}

