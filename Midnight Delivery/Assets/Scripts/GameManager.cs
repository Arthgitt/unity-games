using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int parcelsCollected = 0;
    public int totalParcels = 3;
    public GameObject portalPrefab;

    private void Awake()
{
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject); // persists across scenes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    else
    {
        Destroy(gameObject);
    }
}

void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    if (scene.name != "WinScene" && scene.name != "LoseScene")
    {
        parcelsCollected = 0;
    }
}

    public void ParcelCollected()
    {
        parcelsCollected++;
        if (parcelsCollected >= totalParcels)
        {
            SpawnPortal();
        }
    }

    void SpawnPortal()
    {
        Instantiate(portalPrefab, new Vector3(0,1,0), Quaternion.identity);
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public bool AllParcelsCollected()
{
    return parcelsCollected >= totalParcels;
}

}
