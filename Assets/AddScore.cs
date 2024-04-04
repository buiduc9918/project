using UnityEngine;

public class AddScore : MonoBehaviour
{
    // Start is called before the first frame update
    public BirdControll BirdControll;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        BirdControll = GameObject.Find("Bird").GetComponent<BirdControll>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird"))
        {
            Gamemanager.Instance.AddScore();

        }
    }
}
