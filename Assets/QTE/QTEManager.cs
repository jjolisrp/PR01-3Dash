using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTEManager : MonoBehaviour
{
    [SerializeField] Material canPass;
    [SerializeField] Material canNotPass;

    MeshRenderer wallRenderer;
    Collider wallCollider;

    GameObject caracterGo;

    string[] abecedario = { "A", "B", "C", "D", "E", "F", "G", "H"};
    string[] selectedCaracters;

    int caracterNumber = 0;
    int selectCaracter = 0;
    int indiceDetection;

    KeyCode[] keys;

    private void OnEnable()
    {
        PlayerController.PlayerRestarted += RestartQTE;
    }

    // Start is called before the first frame update
    void Start()
    {
        wallRenderer = transform.parent.gameObject.GetComponent<MeshRenderer>();
        wallRenderer.material = canNotPass;

        wallCollider = transform.parent.gameObject.GetComponent<Collider>();

        indiceDetection = 0;

        SelectCaracters();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys[indiceDetection]))
        {
            Debug.Log("Pulsada tecla: " + indiceDetection);
            caracterGo = transform.GetChild(indiceDetection).gameObject;
            TMP_Text caracterText = caracterGo.GetComponent<TMP_Text>();
            caracterText.color = Color.green;

            if (!(indiceDetection == selectedCaracters.Length -1))
            {
                indiceDetection++;
            }
            else { MakeWallTransferable(); }
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
        TMP_Text caracterText;

        for(int i = 0; i < selectedCaracters.Length; i++)
        {
            caracterGo = transform.GetChild(i).gameObject;
            caracterText = caracterGo.GetComponent<TMP_Text>();
            caracterText.text = selectedCaracters[i];
            caracterText.color = Color.red;
            caracterGo.SetActive(true);
        }
    }

    void HideCaracters()
    {
        TMP_Text caracterText;

        for (int i = 0; i < selectedCaracters.Length; i++)
        {
            caracterGo = transform.GetChild(i).gameObject;
            caracterText = caracterGo.GetComponent<TMP_Text>();
            caracterText.text = selectedCaracters[i];
            caracterText.color = Color.red;
            caracterGo.SetActive(false);
        }
    }

    void RestartQTE() //Cuando termine de hacer funcionar la qte, adjuntar esta funcion al evento de cuando muere el player para reiniciar la QTE
    {
        HideCaracters();
        MakeWallUnTransferable();
        SelectCaracters();
        indiceDetection = 0;
    }

    void MakeWallTransferable()
    {
        wallRenderer.material = canPass;
        wallCollider.enabled = false;
    }

    void MakeWallUnTransferable()
    {
        wallRenderer.material = canNotPass;
        wallCollider.enabled = true;
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

    private void OnDisable()
    {
        PlayerController.PlayerRestarted -= RestartQTE;
    }
}
