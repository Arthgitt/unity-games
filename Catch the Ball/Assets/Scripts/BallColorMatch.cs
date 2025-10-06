using UnityEngine;

public class BallColorMatch : MonoBehaviour
{
    public string targetCornerTag;
    public bool isMatched = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetCornerTag))
        {
            isMatched = true;
            Debug.Log(gameObject.name + " matched!");
        }
    }
}
