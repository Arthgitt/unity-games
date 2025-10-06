/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int SPEED = 8;
    private const int JUMPING_POWER = 7;
    private const float HEIGHT = 1.0f;
    private const float MAX_SPEED = 4.0f;
    public LayerMask groundLayer;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    private bool isJumping;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    private void Update()
    {
         // Are we on the gorund?
        Vector2 feetPosition = new Vector2(transform.position.x, transform.position.y - HEIGHT/2.0f);
        Vector2 groundHitBoxDimensions = new Vector2(0.8f, 0.1f);
        bool isGrounded = Physics2D.OverlapBox(feetPosition,groundHitBoxDimensions, 0.0f, groundLayer);
       
        movement.x = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded){
            isJumping = true;
        }       
      

    }

    void FixedUpdate(){

       rigidBody.AddForce(movement * SPEED);

       Vector2 velocity = rigidBody.linearVelocity;
       velocity.x = Mathf.Clamp(velocity.x, -MAX_SPEED, MAX_SPEED);
       rigidBody.linearVelocity = velocity;


        if (isJumping){
            isJumping = false;
            rigidBody.AddForce(Vector2.up * JUMPING_POWER, ForceMode2D.Impulse);
        }

    }
}
 


 */

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int SPEED = 8;
    private const int JUMPING_POWER = 10; 
    private const float HEIGHT = 1.0f;
    private const float MAX_SPEED = 4.0f;
    public AudioClip jumpingSFX;
    private AudioSource audioSource;
    public LayerMask groundLayer;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    private bool isJumping;
    private bool isGrounded;
    public string nextSceneName;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        isJumping = false;
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            audioSource.PlayOneShot(jumpingSFX);
        }

        
    }

    private void FixedUpdate()
    {
        // Ground detection
        Vector2 feetPosition = new Vector2(transform.position.x, transform.position.y - HEIGHT / 1.0f);
        Vector2 groundHitBoxDimensions = new Vector2(1.0f, 0.2f);

        Collider2D groundCollider = Physics2D.OverlapBox(feetPosition, groundHitBoxDimensions, 0.0f, groundLayer);
        if (groundCollider != null && groundCollider.gameObject != gameObject) // Ignore player itself
        {
            isGrounded = true;
            /* Debug.Log("Touching Ground: " + groundCollider.gameObject.name); */
        }
        else
        {
            isGrounded = false;
            /* Debug.Log("NOT touching ground!"); */
        }

        /* Debug.Log("Is Grounded (FixedUpdate): " + isGrounded); */ 

        // Apply horizontal movement
        rigidBody.AddForce(movement * SPEED);
        Vector2 velocity = rigidBody.linearVelocity;
        velocity.x = Mathf.Clamp(velocity.x, -MAX_SPEED, MAX_SPEED);
        rigidBody.linearVelocity = velocity;

        // Jump only when grounded
        if (isJumping && isGrounded)
        {
            
            isJumping = false;
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, 0); // Reset before jumping
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, JUMPING_POWER);
        }

        // Reset isJumping when landing
        if (isGrounded && rigidBody.linearVelocity.y == 0)
        {
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
    
        Vector2 feetPosition = new Vector2(transform.position.x, transform.position.y - HEIGHT / 2.0f);
        Vector2 groundHitBoxDimensions = new Vector2(1.0f, 0.2f);
        Gizmos.DrawWireCube(feetPosition, groundHitBoxDimensions);
    }


private void Die(){
    Debug.Log(GameData.lives);
    GameData.lives--;
    

    if(GameData.lives == 0){
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScreen");
    }else{
        var activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

    UnityEngine.SceneManagement.SceneManager.LoadScene(activeScene.name);

    }
}


private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Collision detected with: " + collision.gameObject.name); 

    if (collision.CompareTag("DS")) 
    {
        /* Debug.Log(" Switching scene..."); */
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        
    }
    else if(collision.CompareTag("AI"))
    {
        Debug.Log("Object collided but wrong tag: " + collision.gameObject.tag);
        Die();
    }
}

private void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.CompareTag("AI")){
        Die();
    }
}


}




