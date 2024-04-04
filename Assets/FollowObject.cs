using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject bird;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Find the bird GameObject with the tag "Bird"
        bird = GameObject.FindGameObjectWithTag("Bird");
    }

    void Update()
    {
        if (bird != null)
        {
            if (bird.transform.position.x < transform.position.x)
            {
                // Bird is to the left of this object, so flip the sprite
                spriteRenderer.flipX = true;
            }
            else
            {
                // Bird is to the right of this object, so don't flip the sprite
                spriteRenderer.flipX = false;
            }
        }
    }
}
