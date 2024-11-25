using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTipToPlayer : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] ModMenu modMenu;

    TMP_Text tipText;
    GameObject background;

    bool isActive;
    bool keyWasAlreadyPressed;

    // Start is called before the first frame update
    void Start()
    {
        tipText = GetComponent<TMP_Text>();
        background = transform.GetChild(0).gameObject;

        tipText.enabled = false;
        background.SetActive(false);
        keyWasAlreadyPressed = true;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !keyWasAlreadyPressed)
        {
            keyWasAlreadyPressed = true;
            DespauseGame();
        }
    }

    void ShowTipAnStopGame()
    {
        gameManager.GamePause();

        tipText.enabled = true;
        background.SetActive(true);
    }

    void DespauseGame()
    {
        gameManager.GameDespause();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null && !isActive)
            {
                isActive = true;
                keyWasAlreadyPressed = false;
                modMenu.ChangePlayerSpawnPoint();
                ShowTipAnStopGame();
            }
        }
    }
}
