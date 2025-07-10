using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource asBackgroundMusic;
    [SerializeField] private AudioSource asItemExplode;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        volumeSlider.value = asBackgroundMusic.volume;
        PlayInGameMusic();
    }
    private void PlayInGameMusic()
    {      
            asBackgroundMusic.clip = audioClips[0];
            asBackgroundMusic.Play();
    }

    public void PlayExplosion()
    {
        asItemExplode.clip = audioClips[1];
        asItemExplode.Play();
    }

    private void ChangeVolume(float volume)
    {
        asBackgroundMusic.volume = volume;
        asItemExplode.volume = volume;
    }
}
