using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _shotSound, _pickUpHealth, _meHit, _hit; 

    private AudioSource _audioSourceEffect;

    private void Start()
    {
        _audioSourceEffect = GetComponent<AudioSource>(); 
    }

    public void ShotSound()
    {
        _audioSourceEffect.PlayOneShot(_shotSound); 
    }

    public void PickUpHealthSound()
    {
        _audioSourceEffect.PlayOneShot(_pickUpHealth);
    }

    public void MeHitSound()
    {
        _audioSourceEffect.PlayOneShot(_meHit);
    }

    public void HitSound()
    {
        _audioSourceEffect.PlayOneShot(_hit); 
    }
}
