using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDropper : MonoBehaviour
{
    public float threshold = 1.0f;
    private AIUtility.State state = AIUtility.State.IDLE;
    private GameObject player;
    private Rigidbody2D rigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(state == AIUtility.State.IDLE){
         float distanceToPlayer = Mathf.Abs(transform.position.x - player.transform.position.x);

         if(distanceToPlayer <= threshold){
            state = AIUtility.State.ATTACKING;
            rigidBody.gravityScale = 1.0f;
            Destroy(gameObject, 5);
         }
       }
    }
}
