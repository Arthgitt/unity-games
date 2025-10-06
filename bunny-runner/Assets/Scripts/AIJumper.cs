using UnityEngine;

public class AIJumper : MonoBehaviour
{
    private const float JUMPING_FORCE = 8.0f;
    private const float JUMP_DELAY = 2.0f;
    private const float HEIGHT = 1.0f;
    public LayerMask groundLayer;
    public Sprite jumpingSprite;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    private Sprite idleSprite;
    private bool isJumping = false;
    private float timeRemaining;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        idleSprite = spriteRenderer.sprite;
        timeRemaining = JUMP_DELAY;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 feetPosition = new Vector2(transform.position.x, transform.position.y - HEIGHT / 1.0f);
        Vector2 dimensions = new Vector2(1.0f, 0.2f);
        bool isGrounded = Physics2D.OverlapBox(feetPosition,dimensions, 0.0f, groundLayer);

        if(isGrounded){
            spriteRenderer.sprite = idleSprite;
            timeRemaining -= Time.deltaTime;

            if(timeRemaining <= 0.0f){
                isJumping = true;
                timeRemaining = JUMP_DELAY;
            }else{
                spriteRenderer.sprite = jumpingSprite;
            }
        
        }
    }

    private void FixedUpdate(){
        if(isJumping){
            isJumping = false;
            rigidbody.AddForce(Vector2.up * JUMPING_FORCE, ForceMode2D.Impulse);
        }
    }
}
