using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mymixer;
    [SerializeField] private Slider musicslider;
    [SerializeField] private Slider SFXslider;
    static float musicVolume;
    static float sfxVolume;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicvolume") && PlayerPrefs.HasKey("SFXvolume"))
        {
            loadvolume();
        }
        else
        {
            setmusicvolume();
            setSFXvolume();
        }
    }

    public void setmusicvolume()
    {
        musicVolume = musicslider.value;
        mymixer.SetFloat("music", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("musicvolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void setSFXvolume()
    {
        sfxVolume = SFXslider.value;
        mymixer.SetFloat("SFX", Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.SetFloat("SFXvolume", sfxVolume);
        PlayerPrefs.Save();
    }

    private void loadvolume()
    {
        musicslider.value = PlayerPrefs.GetFloat("musicvolume");
        SFXslider.value = PlayerPrefs.GetFloat("SFXvolume");
    }
}
