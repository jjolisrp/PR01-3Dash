using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEManager : MonoBehaviour
{
    string[] abecedario = { "A", "B", "C", "D", "E", "F", "G", "H"};
    string[] selectedCaracters;

    int caracterNumber = 0;
    int selectCaracter = 0;

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
}
