/* using UnityEngine;

public class SpiritEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 3f;
    private int currentPoint = 0;
    private bool chasing = false;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (chasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 0.5f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chasing = true;

        }
    }
}
 */

 using UnityEngine;

public class SpiritEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 3f;
    private int currentPoint = 0;
    private bool chasing = false;
    private Transform player;
    
    private int hitCount = 0;                  // New: count how many times player is touched
    public int maxHits = 2;                    // New: max hits before player dies

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

 /*    private void Update()
    {
        if (chasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            Patrol();
        }
    }
 */

 private void Update()
{
    if (player == null) return; // <-- Prevents crash

    if (chasing)
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
    else
    {
        Patrol();
    }
}

    void Patrol()
    {
        if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 0.5f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
{
    Debug.Log("Touched: " + other.name);  // See what it touches

    if (other.CompareTag("Player"))
    {
        chasing = true;
        hitCount++;

        if (hitCount > maxHits)
        {
            GameManager.instance.LoseGame();
        }
    }
}

}
