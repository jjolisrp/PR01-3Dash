using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTEManager : MonoBehaviour
{
    string[] abecedario = { "A", "B", "C", "D", "E", "F", "G", "H"};
    string[] selectedCaracters;

    int caracterNumber = 0;
    int selectCaracter = 0;

    bool isOnTrigger;
    bool firstCaracterPressed;
    bool secondCaracterPressed;
    bool thirdCaracterPressed;

    KeyCode[] keys;

    // Start is called before the first frame update
    void Start()
    {
        isOnTrigger = false;

        SelectCaracters();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(keys[0]))
        {
            Debug.Log("Presionada 1");
            firstCaracterPressed = true;
        }

        if (Input.GetKeyDown(keys[1]) && firstCaracterPressed)
        {
            Debug.Log("Presionada 2");
            secondCaracterPressed = true;
        }

        if (Input.GetKeyDown(keys[2]) && secondCaracterPressed)
        {
            Debug.Log("Presionada 3");
            thirdCaracterPressed = true;
        }

        if(firstCaracterPressed && secondCaracterPressed && thirdCaracterPressed)
        {
            Debug.Log("Haciendo wall traspasable");
            MakeWallTransferable();
        }
    }

    void SelectCaracters()
    {
        caracterNumber = Random.Range(1, 3);

        selectedCaracters = new string[caracterNumber];

        keys = new KeyCode[caracterNumber];

        for (int i = 0; i < caracterNumber; i++)
        {
            selectCaracter = Random.Range(0, abecedario.Length);

            selectedCaracters[i] = abecedario[selectCaracter];

            keys[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), selectedCaracters[i]); //Convierte el string en un keycode, para poder usar Input.GetKey
        }
    }

    void UnhideSelectedCaracters()
    {
        GameObject caracterGo;
        TMP_Text caracterText;

        for(int i = 0; i < selectedCaracters.Length; i++)
        {
            caracterGo = transform.GetChild(i).gameObject;
            caracterText = caracterGo.GetComponent<TMP_Text>();
            caracterText.text = selectedCaracters[i];
            caracterGo.SetActive(true);
        }
    }

    void RestartQTE() //Cuando termine de hacer funcionar la qte, adjuntar esta funcion al evento de cuando muere el player para reiniciar la QTE
    {

    }

    void MakeWallTransferable()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null)
            {
                isOnTrigger = true;

                UnhideSelectedCaracters();
            }
        }
    }
}
