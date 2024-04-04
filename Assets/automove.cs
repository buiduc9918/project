using System.Collections;
using UnityEngine;

public class AutoMove : MonoBehaviour
{

    void Start()
    {
        // Start the movement sequence
        StartCoroutine(CompleteSequence(transform));
    }

    // Coroutine to complete the movement sequence
    private IEnumerator CompleteSequence(Transform player)
    {
        while (true)
        {

            //   yield return MoveTo(player, new Vector2(-1f, player.position.y));

            //   yield return MoveTo(player, new Vector2(1, player.position.y));

            yield return MoveTo(player, new Vector2(player.position.x, 0.01f));
            yield return MoveTo(player, new Vector2(player.position.x, -1.47f));

            yield return new WaitForSeconds(0.5f);
        }

    }

    // Coroutine to move from current position to a specified position
    private IEnumerator MoveTo(Transform subject, Vector3 targetPosition)
    {
        while (Vector3.Distance(subject.position, targetPosition) > 0.01f)
        {
            // Move towards the target position
            subject.position = Vector3.MoveTowards(subject.position, targetPosition, 5 * Time.deltaTime);

            yield return null;
        }

        // Ensure the subject reaches the target position precisely
        subject.position = targetPosition;
    }

    void Update()
    {
        // Uncomment the following line if you want to run the movement sequence continuously
        // if (!isMoving) StartCoroutine(CompleteSequence(transform));
        transform.eulerAngles = Vector3.zero;
    }
}