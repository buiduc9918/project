using System.Collections;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    public static BirdAnimation instance;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    private BirdController birdController;

    private void Awake()
    {
        birdController = GetComponent<BirdController>();
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Change()
    {
        if (birdController.buff == true)
            InvokeRepeating("BlinkColor", 0.15f, 0.15f);
        else
        {
            CancelInvoke("BlinkColor");
            Player1.SetActive(true);
            Player2.SetActive(false);
            Player3.SetActive(false);
        }
    }



    private void BlinkColor()
    {
        StartCoroutine("Blink");
    }
    IEnumerator Blink()
    {
        Player1.SetActive(true);
        Player2.SetActive(false);
        Player3.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        Player1.SetActive(false);
        Player2.SetActive(true);
        Player3.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        Player1.SetActive(false);
        Player2.SetActive(false);
        Player3.SetActive(true);
        yield return new WaitForSeconds(0.05f);
    }
}


//34531174
