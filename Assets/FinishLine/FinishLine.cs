using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            //Para futuro: tiene que llamar a finishgame de game manager
            Debug.Log("FinishLine alcanzado");

            SceneManager.LoadScene("Prototype", LoadSceneMode.Single);

            gameManager.RestartLevel();
        }
    }
}
