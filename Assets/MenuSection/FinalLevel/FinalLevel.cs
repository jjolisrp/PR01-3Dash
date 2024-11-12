using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalLevel : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerController player;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] MenuFader finalLevelFader;
    [SerializeField] AudioSource gameMusic;
    [SerializeField] AudioSource successAudio;
    [SerializeField] TMP_Text deadCount;


    private void OnEnable()
    {
        restartButton.onClick.AddListener(gameManager.RestartLevel);
        mainMenuButton.onClick.AddListener(gameManager.FinishGame);
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

        gameManager.GamePause();

        deadCount.text = $"Deads: {player.deathCount -1}";
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
        restartButton.onClick.RemoveListener(gameManager.RestartLevel);
        mainMenuButton.onClick.RemoveListener(gameManager.FinishGame);
    }
}
