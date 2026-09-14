using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("全方向の壁接触状態")]
    public bool isWallUp = false;
    public bool isWallDown = false;
    public bool isWallLeft = false;
    public bool isWallRight = false;

    [Header("移動の設定")]
    [SerializeField] private float moveDistance = 1.0f; // 移動距離（上方向）
    [SerializeField] private float duration = 0.3f;

    [Header("コンポーネント")]
    [SerializeField] private Animator animator; // アニメーターの参照

    private bool isMoving = false;
    private int dirIndex = 1;






    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) 
            return;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            dirIndex = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            dirIndex = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            dirIndex = 2;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            dirIndex = 3;
        }

        if (animator != null) animator.SetInteger("direction", dirIndex);

        //if (isMoving) return;

        Vector3 inputDir = Vector3.zero;

        // --- 入力チェック（壁がある方向への移動はブロックする） ---
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //dirIndex = 0;
            if (!isWallUp)
            {
                inputDir = Vector3.up;      // 上に壁がない時だけ移動
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //dirIndex = 1;
            if (!isWallDown)
            {
                inputDir = Vector3.down;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //dirIndex = 2;
            if (!isWallLeft)
            {
                inputDir = Vector3.left;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //dirIndex = 3;
            if (!isWallRight)
            {
                inputDir = Vector3.right;
            }
        }

        // 移動方向が設定されていれば移動開始
        if (inputDir != Vector3.zero)
        {
            //if (animator != null) animator.SetInteger("direction", dirIndex);
            StartCoroutine(MoveRoutine(inputDir));
        }
    }

    private IEnumerator MoveRoutine(Vector3 direction)
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + direction * moveDistance;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            // 進行割合（0.0 〜 1.0）を計算してスムーズに補間
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            yield return null; // 1フレーム待機
        }

        // 誤差をなくすため最後にピッタリ合わせる
        transform.position = targetPos;

        isMoving = false;
    }

    public void SetWallTouch(Direction dir, bool isTouching)
    {
        // 1. 該当する方向のフラグを更新（小文字のみ指定）
        switch (dir)
        {
            case Direction.Up:
                isWallUp = isTouching;
                break;
            case Direction.Down:
                isWallDown = isTouching;
                break;
            case Direction.Left:
                isWallLeft = isTouching;
                break;
            case Direction.Right:
                isWallRight = isTouching;
                break;
        }

        // 2. ログの出力
        string dirName = GetDirectionName(dir);

        if (isTouching)
        {
            Debug.Log($"【壁検知】{dirName} の壁に触れました！ (true)");
        }
        else
        {
            Debug.Log($"【壁検知】{dirName} の壁から離れました！ (false)");
        }
    }


    // ログ表示用に方向の日本語名を返す
    private string GetDirectionName(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                return "上";
            case Direction.Down:
                return "下";
            case Direction.Left:
                return "左";
            case Direction.Right:
                return "右";
            default:
                return "";
        }
    }


}