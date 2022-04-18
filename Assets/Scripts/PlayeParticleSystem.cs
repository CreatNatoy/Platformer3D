using UnityEngine;

public class PlayeParticleSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void Play()
    {
        _particleSystem.Play();
        Debug.Log("Particle system");
    }
}
