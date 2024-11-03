using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] string levelName;
    [SerializeField] Button levelButton;

    private void OnEnable()
    {
        levelButton.onClick.AddListener(LoadLevel);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
