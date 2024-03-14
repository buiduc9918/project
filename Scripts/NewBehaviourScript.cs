using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 3f;
    void Start()
    {

    }

    void Update()
    {

        if (Mathf.Abs(transform.position.y + 1.4f) >= 2.3)
        {
            speed *= -1;
        }
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}
