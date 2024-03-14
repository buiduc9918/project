using UnityEngine;

public class MoveRightFrefabs : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.left * Random.Range(3f, 6f) * Time.deltaTime);
        if (transform.position.x < -60)
        {
            Destroy(gameObject);
        }
    }
}
