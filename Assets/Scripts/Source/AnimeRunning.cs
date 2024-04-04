using System.Collections;
using UnityEngine;

public class AnimeRunning : MonoBehaviour
{
    public Sprite[] sprite;
    public SpriteRenderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SpriteLib());
    }
    IEnumerator SpriteLib()
    {
        int i = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            renderer.sprite = sprite[i];
            i++;
            i = i % sprite.Length;
        }
    }
}
