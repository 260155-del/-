
using UnityEngine;

public class door : MonoBehaviour
{
    [Header("移動先スポーンポイント")]
    [SerializeField] private GameObject spawnPoint;

    private bool playerInside = false;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.Space))
        {
            if (spawnPoint == null)
            {
                Debug.LogError("ワープ先が設定されていません！");
                return;
            }

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                player.transform.position = spawnPoint.transform.position;
                Debug.Log("ワープしました！");
            }
            else
            {
                Debug.LogError("Playerが見つかりません！");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("スペースキーでワープします");
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
