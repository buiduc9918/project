using UnityEngine;

public class matdiem : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            Gamemanager.Instance.ResetLevel();
        }
    }
}
