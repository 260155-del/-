using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPersistence : MonoBehaviour
{
    public static PlayerPersistence Instance;

    public string nextSpawnPoint = "";

    private Rigidbody2D rb;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (string.IsNullOrEmpty(nextSpawnPoint))
            return;

        GameObject spawn = GameObject.Find(nextSpawnPoint);

        if (spawn == null)
        {
            Debug.LogWarning(nextSpawnPoint + " ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
            return;
        }

        if (rb != null)
        {
            rb.position = spawn.transform.position;
            rb.linearVelocity = Vector2.zero;
        }

        transform.position = spawn.transform.position;
    }
}