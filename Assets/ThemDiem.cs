using UnityEngine;

public class ThemDiem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            Gamemanager.Instance.AddScore();
        }
    }
}
