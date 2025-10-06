using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private const int SPEED = 8;
    private const int JUMPING_POWER = 7;
    private const double DEFAULT_TIME_LIMIT = 60.0;
    private const double FALL_LIMIT = -8.0;
    private const float HEIGHT = 1.0f;

    public TMP_Text scoreText;
    public TMP_Text timeText;
    
    public AudioClip jumpingSFX;
    public AudioClip scoreSFX;
    public double timeLimit;
    public LayerMask groundLayer;
    private AudioSource audioSource;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    private int score;
    private Vector3 initialPosition;

    private bool isJumping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        isJumping = false;
        score = 0;
        initialPosition = transform.position;
        

        if(timeLimit <= 0) timeLimit = DEFAULT_TIME_LIMIT;
    }

    // Update is called once per frame: time invariant
    private void Update()
    {   
        if(transform.position.y <= FALL_LIMIT) transform.position = initialPosition;
        
        //the amount of time that has passed from the last frame to this current frame
        timeLimit -= Time.deltaTime;
        timeText.text = "Time Left: " + timeLimit.ToString("0");
        
        if (timeLimit <= 0) UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScreen");

        // Are we on the gorund?
        Vector2 bottomOfBall = new Vector2(transform.position.x, transform.position.y - HEIGHT/2.0f);
        Vector2 groundHitBoxDimensions = new Vector2(0.8f, 0.1f);
        bool isGrounded = Physics2D.OverlapBox(bottomOfBall,groundHitBoxDimensions, 0.0f, groundLayer);

        movement.x = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded){
            isJumping = true;
            audioSource.PlayOneShot(jumpingSFX);
        }
    }

    // FixedUpadate is for Physics: time variant
    void FixedUpdate(){
        rigidBody.AddForce(movement * SPEED);

        if (isJumping){
            isJumping = false;
            rigidBody.AddForce(Vector2.up * JUMPING_POWER, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Racket")){
            score++; 
            scoreText.text = "Score: " + score.ToString();
            audioSource.PlayOneShot(scoreSFX);
            Destroy(collision.gameObject);
        }
    }

    public int getScore(){
        return score;
    }

}
