using UnityEngine;
using UnityEngine.UI;

public class OnOffMove : MonoBehaviour
{
    public GameObject bird1;
    public GameObject bird2;
    public GameObject bird3;
    public Movement movement1;
    public Movement movement2;
    public Movement movement3;
    public bool test;
    public Button Button2;
    Vector3 location;
    private void Start()
    {
        location = transform.position;
        test = false;
        Button2 = GetComponent<Button>();
        movement1 = bird1.GetComponent<Movement>();
        movement2 = bird2.GetComponent<Movement>();
        movement3 = bird3.GetComponent<Movement>();
        Button2.onClick.AddListener(setbird);

    }

    private void Update()
    {
        movement1.enabled = test;
        movement2.enabled = test;
        movement3.enabled = test;
    }
    public void setbird()
    {
        test = !test;
        if (test == true)
        {
            transform.position = location;
        }
    }

}
