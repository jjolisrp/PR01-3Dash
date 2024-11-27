using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    [SerializeField] GameObject checkpointFlag;

    Vector3 newPositionPlayer;
    Vector3 newPositionRbPlayer;

    private void OnEnable()
    {
        checkpointFlag = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ChangePlayerSpawnPoint();
            GameManager.instance.SetNewItemsStartQuantity();
        }
    }

    public void ChangePlayerSpawnPoint()
    {
        newPositionPlayer = GameManager.instance.GetPlayerPosition();
        newPositionRbPlayer = GameManager.instance.GetPlayerRbPosition();

        GameManager.instance.SetPlayerPosition(newPositionPlayer);
        GameManager.instance.SetPlayerRbPosition(newPositionRbPlayer);

        checkpointFlag.transform.position = newPositionPlayer + new Vector3(0f, 0.5f, 0f);
    }
}
