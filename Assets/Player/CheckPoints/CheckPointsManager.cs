using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerItems playerItems;
    [SerializeField] GameObject checkpointFlag;

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
            playerItems.SaveItemsValueOnCheckPoint();
        }
    }

    public void ChangePlayerSpawnPoint()
    {
        playerController.startPosition = playerController.transform.position;
        playerController.startRbPosition = playerController.transform.GetComponent<Rigidbody>().position;
    }
}
