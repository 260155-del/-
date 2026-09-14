using UnityEngine;
using UnityEngine.UI;

public class signboard1 : MonoBehaviour
{
    private bool isPlayerInside = false; // プレイヤーが近くにいるかどうか

    public Text messageText; //喋る内容を表示するためのText変数
    public Image backgroundColorImage; //喋る内容のテキストの背景

    private void Start()
    {
        WhenExitSignArea();
    }

    void Update()
    {
        // プレイヤーが近くにいて、かつスペースキーが押されたとき
        if (isPlayerInside && Input.GetKeyDown(KeyCode.Space))
        {
            ReadSign();
        }
    }

    // プレイヤーが検知エリアに入ったとき
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("看板の前に立ちました。（スペースキーで読む）");
        }
    }

    // プレイヤーが検知エリアから出たとき
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            WhenExitSignArea();
            Debug.Log("看板から離れました。");
        }
    }

    // メッセージを表示する処理
    public virtual void ReadSign()
    {
        //「こんにちは」を代入する（＝こんにちはと表示）
        messageText.text = "こっちちゃうよバーガー";

        //Imageコンポーネントの有効化（＝表示する）
        backgroundColorImage.enabled = true;
        Debug.Log("【看板のメッセージ】ここに文章を表示します！");
    }

    public void WhenExitSignArea()
    {
        //何も代入しない（＝何も表示しない）
        messageText.text = "";

        //Imageコンポーネントの無効化（＝表示しない）
        backgroundColorImage.enabled = false;
    }
}