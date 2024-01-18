
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class musicsettings : MonoBehaviour
{


    [SerializeField] private AudioMixer mymixer;
    [SerializeField] private Slider musicslider;
    [SerializeField] private Slider SFXslider;
    static float musicVolume;
    static float sfxVolume;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicvolume"))
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
        mymixer.SetFloat("music", Mathf.Log10(musicVolume)*20);
        PlayerPrefs.GetFloat("musicvolume");
    }
    public void setSFXvolume()
    {
        sfxVolume = SFXslider.value;
        mymixer.SetFloat("SFX", Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.GetFloat("SFXvolume");
    }
    private void loadvolume()
    {
        musicslider.value = PlayerPrefs.GetFloat("musicvolume");
        SFXslider.value = PlayerPrefs.GetFloat("SFXvolume");
        setmusicvolume();
        setSFXvolume();
    }

}
