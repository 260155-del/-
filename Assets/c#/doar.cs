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
        if (playerInside && Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerPersistence.Instance != null)
            {
                PlayerPersistence.Instance.nextSpawnPoint = spawnPointName;
            }

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