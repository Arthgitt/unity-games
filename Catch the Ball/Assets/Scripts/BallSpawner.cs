using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] balls;

    void Start()
    {
        foreach (GameObject ball in balls)
        {
            ball.transform.position = new Vector3(Random.Range(-4f, 4f), 1f, Random.Range(-4f, 4f));
        }
    }
}
