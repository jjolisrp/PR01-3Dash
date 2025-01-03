using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalLevel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerController player;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] MenuFader finalLevelFader;
    [SerializeField] AudioSource gameMusic;
    [SerializeField] AudioSource successAudio;
    [SerializeField] TMP_Text deathsCount;

    public delegate void OnPlayerFinishLevel();
    public static event OnPlayerFinishLevel PlayerFinishedLevel;

    private void OnEnable()
    {
        restartButton.onClick.AddListener(GameManager.instance.RestartLevel);
        mainMenuButton.onClick.AddListener(GameManager.instance.FinishGame);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowFinalLevelCanvas()
    {
        finalLevelFader.FadeIn();

        gameMusic.Stop();
        successAudio.Play();

        GameManager.instance.GamePause();

        if(PlayerFinishedLevel != null)
        {
            PlayerFinishedLevel.Invoke();
        }

        deathsCount.text = $"Deaths: {player.deathCount -1}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            PlayerController player = other.transform.GetComponent<PlayerController>();

            if(player != null)
            {
                ShowFinalLevelCanvas();
                player.StopPlayer();
            }
        }
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(GameManager.instance.RestartLevel);
        mainMenuButton.onClick.RemoveListener(GameManager.instance.FinishGame);
    }
}
