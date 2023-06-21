using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixerGroup mixer;
    private float _volume;
    

    private void Start()
    {
        _volume = PlayerPrefs.GetFloat("MusicVolume");
        slider.value = _volume;
    }

    public void ChangeVolume(float volume)
    {
        
        PlayerPrefs.SetFloat("MusicVolume", volume);
        print(PlayerPrefs.GetFloat("MusicVolume"));
        mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80f, 0f, volume));
    }        
}
