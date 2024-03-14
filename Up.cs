//using System.Math;
using UnityEngine;

public class Up : MonoBehaviour
{
    public static Up Instance;
    private float speed = 1f;
    private BirdController birdController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        birdController = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdController>();
    }
    public void MoveUp()
    {
        if (birdController.fly == true)
        {
            if (System.Math.Abs(transform.position.y) > 5)
            {
                speed *= -1;
            }
            transform.Translate(Vector3.up * speed * Time.deltaTime);

        }
    }
}
