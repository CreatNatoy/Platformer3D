using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music; 

    public void SetMusicEnabled(bool state)
    {
        _music.enabled = state;
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value; 
    }
}
