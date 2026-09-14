/*
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class doar2 : doar
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Changescene()
    {
        //SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
        //Imageコンポーネントの有効化（＝表示する）
        //backgroundColorImage.enabled = true;
        Debug.Log("ドアでスペースキーが押されました");

        if (PlayerPersistence.instance != null)
        {
            PlayerPersistence.instance.targetSpawnName = targetSpawnPointName;
        }

        StartCoroutine(ReturnToPreviousSceneRoutine(targetSceneName));
    }

    private IEnumerator ReturnToPreviousSceneRoutine(string previousSceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Scene prevScene = SceneManager.GetSceneByName(previousSceneName);

        foreach (GameObject rootObj in prevScene.GetRootGameObjects())
        {
            rootObj.SetActive(true);
        }

        SceneManager.SetActiveScene(prevScene);

        if (PlayerPersistence.instance != null)
        {
            PlayerPersistence.instance.MoveToSpawnPointInScene(prevScene);
        }

        yield return SceneManager.UnloadSceneAsync(currentScene);
    }
}
*/