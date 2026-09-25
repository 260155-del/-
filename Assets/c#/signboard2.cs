using UnityEngine;

public class signboard2 : signboard
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    public override void ReadSign()
    {
        //「こんにちは」を代入する（＝こんにちはと表示）
        messageText.text = "この扉 DOARっていうんだぜ!";

        //Imageコンポーネントの有効化（＝表示する）
        backgroundColorImage.enabled = true;
        Debug.Log("【看板のメッセージ】ここに文章を表示します！");
    }

}
