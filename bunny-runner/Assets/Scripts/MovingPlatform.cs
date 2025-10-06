using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 3.0f; // Distance to move left & right
    public float moveSpeed = 2.0f; // Speed of movement

    private Vector3 startPosition;
    private int direction = 1; // 1 = right, -1 = left

    void Start()
    {
        startPosition = transform.position; // Store the starting position
    }

    void Update()
    {
        // Move platform left and right
        transform.position = new Vector3(
            startPosition.x + Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance,
            transform.position.y,
            transform.position.z
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Make player a child of the platform to move with it
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Remove player from platform when jumping off
            collision.transform.SetParent(null);
        }
    }
}
