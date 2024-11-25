using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModMenu : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ChangePlayerSpawnPoint();
        }
    }

    public void ChangePlayerSpawnPoint()
    {
        playerController.startPosition = playerController.transform.position;
        playerController.startRbPosition = playerController.transform.GetComponent<Rigidbody>().position;
    }
}
