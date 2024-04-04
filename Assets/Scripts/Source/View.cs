using UnityEngine;

public class View : MonoBehaviour
{
    public Transform localposition;
    public Vector3 positionx;
    public float speed = 3;
    public GameObject backGd;
    public GameObject Gd;
    public Transform BackGround;
    public Transform Ground;
    public float direction;

    private void Awake()
    {
        localposition = transform;
        positionx = transform.position;
        BackGround = backGd.GetComponent<Transform>();
        Ground = Gd.GetComponent<Transform>();
    }

    void Update()
    {
        if (BackGround.position.x - positionx.x < -direction) commback(BackGround);
        if (Ground.position.x - positionx.x < -direction) commback(Ground);
        MoveBackground(BackGround);
        MoveBackground(Ground);
    }

    private void MoveBackground(Transform background) => background.position += Vector3.left * speed * Time.deltaTime;
    private void commback(Transform gameObject)
    {
        float y = gameObject.position.y;
        gameObject.position = new Vector3(positionx.x + direction, y, positionx.z);
    }
}
