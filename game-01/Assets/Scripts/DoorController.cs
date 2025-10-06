using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public const int WINNING_SCORE = 3;
    public string nextSceneName;
    
  private void OnTriggerEnter2D(Collider2D collision){
    if(collision.CompareTag("Player") && collision.gameObject.GetComponent<PlayerController>().getScore() == WINNING_SCORE){
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
  }
}
