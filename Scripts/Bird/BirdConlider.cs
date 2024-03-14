using System;
using System.Collections;
using UnityEngine;

public class BirdConlider : MonoBehaviour
{
    private CapsuleCollider2D birdCollider;
    private BirdAnimation birdAnimation;
    private BoxCollider2D greenCollider;
    private BoxCollider2D pipeCollider;
    private BirdController birdController;
    public float time = 10f;
    private void Awake()
    {
        birdController = GetComponent<BirdController>();
        birdCollider = GetComponent<CapsuleCollider2D>();
        birdCollider.size = new Vector2(0.24f, 0.00001f);
        try
        {
            greenCollider = GameObject.FindWithTag("Ground").GetComponent<BoxCollider2D>();
            pipeCollider = GameObject.FindWithTag("Pipe").GetComponent<BoxCollider2D>();
            greenCollider.isTrigger = false;
            pipeCollider.isTrigger = false;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message + " Waiting ");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("redStar"))
        {
            StartCoroutine(nameof(setup));
        }
    }

    IEnumerator setup()
    {
        birdController.buff = true;
        greenCollider.isTrigger = true;
        pipeCollider.isTrigger = true;
        birdCollider.size = new Vector2(0.6f, 0.00001f);
        yield return new WaitForSeconds(10f);
        delay();
    }
    public void delay()
    {
        birdController.buff = false;
        greenCollider.isTrigger = false;
        pipeCollider.isTrigger = false;
        birdCollider.size = new Vector2(0.24f, 0.00001f);
    }
}
