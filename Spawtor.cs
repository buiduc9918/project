using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawtor : MonoBehaviour
{
    public GameObject[] prefabs;
    public BirdController birdController;
    public Button Button;

    private void Awake()
    {
        birdController = GameObject.FindWithTag("Bird").GetComponent<BirdController>();
    }

    private void Start()
    {
        Button.onClick.AddListener(startgspawn);
    }
    public void startgspawn()
    {
        StartCoroutine(SpawnWithDelay());
    }

    IEnumerator SpawnWithDelay()
    {
        while (true) // You can modify this condition based on your requirements
        {
            yield return new WaitForSeconds(2);
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, transform.rotation);
    }
}
