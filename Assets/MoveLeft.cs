using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed = 4;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
