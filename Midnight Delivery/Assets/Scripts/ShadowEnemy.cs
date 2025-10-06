using UnityEngine;

public class ShadowEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 lastPlayerPosition;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure your Player GameObject is tagged as 'Player'");
        }
    }

    void Update()
    {
        if (player == null) return; // Prevent null reference crash

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.LoseGame();
        }
    }
}
