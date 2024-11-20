using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    [SerializeField] ParticleSystem evaporation;

    public enum Particle
    {
        Evaporation
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EmitParticles(int count, Transform nextLocation, Particle particle)
    {
        if(particle == Particle.Evaporation)
        {
            evaporation.transform.position = nextLocation.position;
            evaporation.Emit(count);
        }
    }
}
