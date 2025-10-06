/* using UnityEngine;

public class AIWalker : MonoBehaviour
{
    public float threshold = 3.0f;
    public float speed = 1.0f;
    public LayerMask groundLayer;

    private AIUtility.State state = AIUtility.State.IDLE;
    private Rigidbody2D rigidbody;
    private GameObject player;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(state == AIUtility.State.IDLE){
            float distance = Vector3.Distance(transform.position, player.transform.position);
           if (distance < threshold) state = AIUtility.State.WALKING;

        }
        else if(state == AIUtility.State.WALKING){
            //Left sensor
            if(!IsGrounded(-0.5f,-0.6f) && speed < 0) speed *= -1;

            //Right sensor
            if(!IsGrounded(0.5f,-0.6f) && speed > 0) speed *= -1;


            Vector2 velocity = rigidbody.linearVelocity;
            velocity.x = speed;
            rigidbody.linearVelocity = velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("AI")){
            speed *= -1;
        }
    }

    public bool IsGrounded(float xOffset, float yOffset){
        var hitBoxPosition = new Vector2(transform.position.x + xOffset, transform.position.y + yOffset);

        var dimensions = new Vector2(0.1f,0.1f);

        var isGrounded = Physics2D.OverlapBox(hitBoxPosition, dimensions, 0, groundLayer);

        return isGrounded;
    }
}
 */

 using UnityEngine;

public class AIWalker : MonoBehaviour
{
    public float threshold = 3.0f;
    public float speed = 1.0f;
    public LayerMask groundLayer;

    private AIUtility.State state = AIUtility.State.IDLE;
    private Rigidbody2D rigidbody;
    private GameObject player;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        

        if (state == AIUtility.State.IDLE)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < threshold) state = AIUtility.State.WALKING;
        }
        else if (state == AIUtility.State.WALKING)
        {
            // Left sensor
            if (!IsGrounded(-0.35f, -0.7f) && speed < 0)
            {
                Debug.Log("🚨 AI reached LEFT edge! Turning right.");
                speed *= -1;
            }

            // Right sensor
            if (!IsGrounded(0.35f, -0.7f) && speed > 0)
            {
                Debug.Log("🚨 AI reached RIGHT edge! Turning left.");
                speed *= -1;
            }

            Vector2 velocity = rigidbody.linearVelocity;
            velocity.x = speed;
            rigidbody.linearVelocity = velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AI"))
        {
            Debug.Log("AI Collided with another AI! Reversing direction.");
            speed *= -1;
        }
    }

    public bool IsGrounded(float xOffset, float yOffset)
    {
        Vector2 hitBoxPosition = new Vector2(transform.position.x + xOffset, transform.position.y + yOffset);
        Vector2 dimensions = new Vector2(0.2f, 0.15f); // ✅ Increased size

        bool isGrounded = Physics2D.OverlapBox(hitBoxPosition, dimensions, 0, groundLayer);

        Debug.DrawRay(hitBoxPosition, Vector2.down * 0.2f, isGrounded ? Color.green : Color.red);

        return isGrounded;
    }
}
