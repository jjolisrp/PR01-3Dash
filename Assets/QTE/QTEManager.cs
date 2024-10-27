using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTEManager : MonoBehaviour
{
    GameObject keyPressTrigger;

    string[] abecedario = { "A", "B", "C", "D", "E", "F", "G", "H"};
    string[] selectedCaracters;

    int caracterNumber = 0;
    int selectCaracter = 0;

    // Start is called before the first frame update
    void Start()
    {
        keyPressTrigger = GetComponentInChildren<GameObject>();

        SelectCaracters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectCaracters()
    {
        caracterNumber = Random.Range(0, 3);
        
        for(int i = 0; i < caracterNumber; i++)
        {
            selectCaracter = Random.Range(0, abecedario.Length);

            selectedCaracters[i] = abecedario[selectCaracter];
        }
    }

    void UnhideSelectedCaracters()
    {
        GameObject caracterGo;
        TMP_Text caracterText;

        for(int i = 0; i < selectedCaracters.Length; i++)
        {
            caracterGo = keyPressTrigger.transform.GetChild(i).gameObject;
            caracterText = caracterGo.GetComponent<TMP_Text>();
            caracterText.text = selectedCaracters[i];
            caracterGo.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null)
            {
                UnhideSelectedCaracters();
            }
        }
    }
}
