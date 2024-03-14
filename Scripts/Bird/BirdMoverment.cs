using UnityEngine;
using UnityEngine.SceneManagement;


public class BirdMoverment : MonoBehaviour
{
    private float streng = 5f;
    public float gravi = 9.8f;
    public int world = 1;
    public Vector2 Direction = Vector2.up;
    private Rigidbody2D birdRb;
    private RectTransform rectTransform;

    private void Awake()
    {
        birdRb = GetComponent<Rigidbody2D>();
        rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        birdRb.isKinematic = true;
    }
    public void OnDisable()
    {
        birdRb.isKinematic = true;
    }
    public void OnEnable()
    {
        birdRb.isKinematic = false;
    }
    private void Update()
    {
        GroundedMovement();
    }
    public void BirdDead(bool dead)
    {
        if (dead == true)
        {
            SceneManager.LoadScene(world.ToString());
        }
    }
    private void GroundedMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdRb.isKinematic == false)
        {
            birdRb.velocity = Direction * streng;
            rectTransform.eulerAngles = new Vector3(0, 0, 30);
        }
        if (Input.GetKeyUp(KeyCode.Space) && birdRb.isKinematic == false)
        {
            rectTransform.eulerAngles = new Vector3(0, 0, -10);
        }
        if (Input.GetKey(KeyCode.Space) && birdRb.isKinematic == false)
        {
            rectTransform.eulerAngles = new Vector3(0, 0, 10);
        }
    }

}