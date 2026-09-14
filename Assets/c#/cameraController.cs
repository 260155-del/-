using UnityEngine;

public class cameraControl : MonoBehaviour
{
    [Header("追従ターゲット")]
    [SerializeField] private Transform target; // 主人公（Player）を指定

    [Header("追従の設定")]
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10); // カメラとプレイヤーの距離
    [SerializeField] private float smoothTime = 0.25f;

    private Vector3 velocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (target == null)
        {
            //transform.position = target.position + offset;
            if (PlayerPersistence.Instance != null)
            {
                target = PlayerPersistence.Instance.transform;
            }
            else
            {
                // バックアップ：「Player」タグのついたオブジェクトを探す
                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    target = player.transform;
                }
            }
        }
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // 目標とするカメラ位置を計算（プレイヤー位置 + オフセット）
        Vector3 targetPosition = target.position + offset;

        // 現在位置から目標位置へ滑らかに移動
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
