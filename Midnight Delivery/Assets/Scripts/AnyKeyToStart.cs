using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyToStart : MonoBehaviour
{
    public string nextSceneName;

    void Update()
    {
        if (Input.anyKeyDown) // Detects any key press
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
