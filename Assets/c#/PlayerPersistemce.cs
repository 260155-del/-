using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPersistence : MonoBehaviour
{
    public static PlayerPersistence Instance;

    [Header("次のスポーンポイント")]
    public string nextSpawnPoint = "";

    private Rigidbody2D rb;

    private void Awake()
    {
        if (Instance != null && Instance != this)
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(MoveToSpawnPoint());
    }

    private IEnumerator MoveToSpawnPoint()
    {
        // シーンのオブジェクトが生成されるまで少し待つ
        yield return null;

        if (string.IsNullOrEmpty(nextSpawnPoint))
        {
            Debug.LogWarning("スポーンポイント名が設定されていません");
            yield break;
        }

        GameObject spawn = GameObject.Find(nextSpawnPoint);

        if (spawn == null)
        {
            Debug.LogError(
                "スポーンポイント「" + nextSpawnPoint +
                "」が見つかりません！"
            );

            yield break;
        }

        // スポーンポイントの位置を取得
        Vector3 spawnPosition = spawn.transform.position;

        // プレイヤーを移動
        transform.position = spawnPosition;

        // Rigidbody2Dも移動
        if (rb != null)
        {
            rb.position = spawnPosition;
            rb.linearVelocity = Vector2.zero;
        }

        Debug.Log(
            "スポーンポイント「" +
            nextSpawnPoint +
            "」へ移動しました"
        );

        // 使用したら消す
        nextSpawnPoint = "";
    }
}


/*using UnityEngine;
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
            Debug.LogWarning(nextSpawnPoint + " が見つかりません");
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
*/