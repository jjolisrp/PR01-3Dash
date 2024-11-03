using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button play;
    [SerializeField] Button options;
    [SerializeField] Button exit;
    [SerializeField] string playScene;

    private void OnEnable()
    {
        play.onClick.AddListener(OnPlay);
        options.onClick.AddListener(OnOptions);
        exit.onClick.AddListener(OnExit);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlay()
    {
        SceneManager.LoadScene(playScene, LoadSceneMode.Single);
    }

    void OnOptions()
    {

    }

    void OnExit()
    {
        Application.Quit();

        EditorApplication.isPlaying = false;
    }

    private void OnDisable()
    {
        play.onClick.RemoveListener(OnPlay);
        options.onClick.RemoveListener(OnOptions);
        exit.onClick.RemoveListener(OnExit);
    }
}
