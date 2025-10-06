using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchChecker : MonoBehaviour
{
    public BallColorMatch[] balls;
    public float timeLimit = 60f;
    private float timeLeft;

    void Start()
    {
        timeLeft = timeLimit;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
            SceneManager.LoadScene("LoseScene");

        bool allMatched = true;
        foreach (var ball in balls)
        {
            if (!ball.isMatched)
                allMatched = false;
        }

        if (allMatched)
            SceneManager.LoadScene("WinScene");
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), "Time Left: " + Mathf.Ceil(timeLeft));
    }
}
