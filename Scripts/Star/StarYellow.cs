using UnityEngine;
public class StarYellow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BirdController birdController;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        birdController = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdController>();
    }
    private void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            birdController.addscore(5);
            spriteRenderer.enabled = false;
            Invoke("cham", 1);
        }
    }
    private void cham()
    {
        spriteRenderer.enabled = true;
    }
}

