using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    Scene currentScene;

    static public LoadingScene instance;
    private void Awake()
    {
        instance = this;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCorutine(sceneName));
    }

    public IEnumerator LoadSceneCorutine(string sceneName)
    {
        //Fade
        {
            Tween fadeTween = canvasGroup.DOFade(1f, 1f);
            do
            {
                yield return new();
            }
            while (fadeTween.IsPlaying());
        }

        //Descargar la escena actual
        if(currentScene.isLoaded)
        {
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(currentScene);
            do
            {
                yield return new();
            }
            while (!unloadOperation.isDone);
        }

        float timeBeforeLoad = Time.realtimeSinceStartup;
        //Cargar la escena
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            do
            {
                yield return new();
            }
            while (!loadOperation.isDone);

            currentScene = SceneManager.GetSceneAt(1);
            Debug.Log(currentScene);
            SceneManager.SetActiveScene(currentScene);
        }

        float timeElapsedLoading = Time.realtimeSinceStartup - timeBeforeLoad;
        if(timeElapsedLoading < 3f)
        {
            yield return new WaitForSeconds(3f - timeElapsedLoading);
        }

        //Fade
        {
            Tween fadeTween = canvasGroup.DOFade(0f, 1f);
            do
            {
                yield return new();
            }
            while (fadeTween.IsPlaying());
        }
    }
    [MenuItem("LoadingScene/Debug/Change to MainMenu")]
    static public void DebugChangeToMainMenuScene()
    {
        LoadingScene.instance.LoadScene("MainMenu");
    }
}
