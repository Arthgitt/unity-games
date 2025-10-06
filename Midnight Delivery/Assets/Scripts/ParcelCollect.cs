
 using UnityEngine;

public class ParcelCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.ParcelCollected();
            Destroy(gameObject);
        }
    }
}
