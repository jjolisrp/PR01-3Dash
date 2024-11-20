using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ParticlesManager : MonoBehaviour
{
    [SerializeField] ParticleSystem evaporation;
    [SerializeField] ParticleSystem playerExplosion;

    public enum Particle
    {
        Evaporation,
        PlayerExplosion
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmitParticles(int count, Transform nextLocation, Particle particle)
    {
        if(particle == Particle.Evaporation)
        {
            evaporation.transform.position = nextLocation.position;
            evaporation.Emit(count);
        }
        else if(particle == Particle.PlayerExplosion)
        {
            playerExplosion.transform.position = nextLocation.position + new Vector3(0, 0.5f, 0);
            playerExplosion.Emit(count);
        }
    }
}
