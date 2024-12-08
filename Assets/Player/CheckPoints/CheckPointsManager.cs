using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    [SerializeField] GameObject checkpointFlag;

    Vector3 newPositionPlayer;
    Vector3 newPositionRbPlayer;

    List<(Vector3 rbPosition, Vector3 position)> playerCheckpoints = new List<(Vector3 rbPosition, Vector3 position)>();

    private void OnEnable()
    {
        checkpointFlag = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        newPositionPlayer = GameManager.instance.GetPlayerPosition();
        newPositionRbPlayer = GameManager.instance.GetPlayerRbPosition();

        playerCheckpoints.Add((newPositionRbPlayer, newPositionPlayer));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ChangePlayerSpawnPoint();
            GameManager.instance.SetNewItemsStartQuantity();
        }

        if(Input.GetKeyDown(KeyCode.F2) && playerCheckpoints.Count > 1)
        {
            DeleteCheckpoint();
        }
    }

    public void ChangePlayerSpawnPoint()
    {
        newPositionPlayer = GameManager.instance.GetPlayerPosition();
        newPositionRbPlayer = GameManager.instance.GetPlayerRbPosition();

        GameManager.instance.SetPlayerPosition(newPositionPlayer);
        GameManager.instance.SetPlayerRbPosition(newPositionRbPlayer);

        checkpointFlag.transform.position = newPositionPlayer + new Vector3(0f, 0.5f, 0f);

        playerCheckpoints.Add((newPositionRbPlayer, newPositionPlayer));
    }

    void DeleteCheckpoint()
    {
        int lastCheckpoint;

        if (playerCheckpoints.Count <= 1)
        {
            checkpointFlag.transform.position = Vector3.up * -50;

            lastCheckpoint = playerCheckpoints.Count - 1;

            GameManager.instance.SetPlayerPosition(playerCheckpoints[lastCheckpoint].position);
            GameManager.instance.SetPlayerRbPosition(playerCheckpoints[lastCheckpoint].rbPosition);
        }
        else
        {
            lastCheckpoint = playerCheckpoints.Count - 1;

            playerCheckpoints.RemoveAt(lastCheckpoint);

            lastCheckpoint = playerCheckpoints.Count - 1;

            checkpointFlag.transform.position = playerCheckpoints[lastCheckpoint].position + new Vector3(0f, 0.5f, 0f);

            GameManager.instance.SetPlayerPosition(playerCheckpoints[lastCheckpoint].position);
            GameManager.instance.SetPlayerRbPosition(playerCheckpoints[lastCheckpoint].rbPosition);
        }
    }
}
