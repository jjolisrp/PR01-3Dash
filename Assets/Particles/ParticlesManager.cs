using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ParticlesManager : MonoBehaviour
{
    [SerializeField] ParticleSystem evaporation;
    [SerializeField] ParticleSystem playerExplosion;
    [SerializeField] ParticleSystem playerJump;

    public enum Particle
    {
        Evaporation,
        PlayerExplosion,
        PlayerJump
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
            playerJump.Clear();
            evaporation.transform.position = nextLocation.position;
            evaporation.Emit(count);
        }
        else if(particle == Particle.PlayerExplosion)
        {
            playerJump.Clear();
            playerExplosion.transform.position = nextLocation.position + new Vector3(0, 0.5f, 0);
            playerExplosion.transform.GetChild(1).GetComponent<AudioSource>().Play();
            playerExplosion.Emit(count);
        }
        else if(particle == Particle.PlayerJump)
        {
            playerJump.Clear();
            playerJump.transform.position = nextLocation.position;
            playerJump.Emit(count);
        }
    }
}
