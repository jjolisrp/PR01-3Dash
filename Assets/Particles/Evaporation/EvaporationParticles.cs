using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaporationParticles : MonoBehaviour
{
    ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EmitEvaporation(Transform nextLocation)
    {
        transform.position = nextLocation.position;

        particles.Emit(50);
    }
}
