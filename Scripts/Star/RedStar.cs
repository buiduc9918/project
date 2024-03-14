using UnityEngine;

public class RedStar : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BirdController birdController;

    private void Awake()
    {
        birdController = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdController>();
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            birdController.addscore(5);
            spriteRenderer.enabled = false;
            Invoke("lamcham", 10f);
        }
    }
    private void lamcham()
    {
        spriteRenderer.enabled = true;
    }
}
