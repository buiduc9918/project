using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 vector = new Vector3(0, 0, -10);
    // Update is called once per frame
    void Update()
    {
        try
        {
            GameObject game = GameObject.FindGameObjectWithTag("Bird");
            transform.position = game.transform.position + vector;
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
