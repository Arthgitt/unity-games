/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        var playerPosition = player.trasform.position;
        var cameraPosition = transform.position;

        cameraPosition.x = playerPosition.x;
        cameraPosition.y = playerPosition.y;
        
        trasform.position = cameraPosition;
    }
}
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        if (player == null)
        {
            Debug.LogError("Player object not found! Make sure the Player has the correct tag.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 cameraPosition = transform.position;

            cameraPosition.x = playerPosition.x;
            cameraPosition.y = playerPosition.y;
        
            transform.position = cameraPosition;
        }
    }
}
