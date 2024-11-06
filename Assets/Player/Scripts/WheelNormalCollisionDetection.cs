using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelNormalCollisionDetection : MonoBehaviour
{
    Collider wheelCollider;

    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updating");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");

        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log("El collider " + contact.thisCollider.name + "choca con el collider " + contact.otherCollider.name);
            Debug.Log("La normal es " + contact.normal);
        }
    }
}
