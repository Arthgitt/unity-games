using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float leftBound = 0.0f;
    public float rightBound = 13.0f;

    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPosition = transform.position;

        if (playerPosition.x > leftBound && playerPosition.x < rightBound){
            cameraPosition.x = playerPosition.x;
            transform.position = cameraPosition;
        }
        
    }
}
