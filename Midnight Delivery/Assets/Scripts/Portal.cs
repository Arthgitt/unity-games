/* using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.AllParcelsCollected())
        {
            GameManager.instance.WinGame();
        }
    }
} */

using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string nextSceneName; // This will show up in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.AllParcelsCollected())
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
