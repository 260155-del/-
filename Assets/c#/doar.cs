using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    [Header("移動先シーン名")]
    [SerializeField] private string sceneName;

    [Header("移動先スポーンポイント名")]
    [SerializeField] private string spawnPointName;

    private bool playerInside = false;

    private void Update()
    {
        // プレイヤーがドアの中にいて、スペースキーを押したら移動
        if (playerInside && Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerPersistence.Instance == null)
            {
                Debug.LogError("PlayerPersistence が見つかりません！");
                return;
            }

            if (string.IsNullOrEmpty(sceneName))
            {
                Debug.LogError("移動先シーン名が設定されていません！");
                return;
            }

            if (string.IsNullOrEmpty(spawnPointName))
            {
                Debug.LogError("スポーンポイント名が設定されていません！");
                return;
            }

            // 次のシーンで出現する場所を保存
            PlayerPersistence.Instance.nextSpawnPoint = spawnPointName;

            Debug.Log(
                "シーン移動: " + sceneName +
                " / スポーンポイント: " + spawnPointName
            );

            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("スペースキーで入れます");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}