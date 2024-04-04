using UnityEngine;


public class Mario : MonoBehaviour
{
    private Animator animator;
    private Vector3 lastPosition;
    private Vector3 latePosition;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        latePosition = transform.position;
        ManagementAnimation(lastPosition, latePosition);
        lastPosition = latePosition; // Gán lastPosition ở cuối của frame
    }

    private void ManagementAnimation(Vector3 lastPosition, Vector3 latePosition)
    {
        Vector3 direction = latePosition - lastPosition;
        if (Mathf.Abs(direction.y) > 0.01)
        {
            animator.SetBool("isJumping", true);
        }
        else if (Mathf.Abs(direction.y) < 0.01)
        {
            animator.SetBool("isJumping", false);
        }
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        animator.SetFloat("xVelocity", Mathf.Abs(direction.x));
        animator.SetFloat("yVelocity", direction.y);
    }


}
