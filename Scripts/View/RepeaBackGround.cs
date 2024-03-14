using UnityEngine;

public class RepeaBackGround : MonoBehaviour
{
    public Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= startPos.x - 120)
        {
            transform.position = startPos;
        }
    }
}
