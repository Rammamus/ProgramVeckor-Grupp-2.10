
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class musicsettings : MonoBehaviour
{


    [SerializeField] private AudioMixer mymixer;
    [SerializeField] private Slider musicslider;
    [SerializeField] private Slider SFXslider;
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
        float volume = musicslider.value;
        mymixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.GetFloat("musicvolume");
    }
    public void setSFXvolume()
    {
        float volume = SFXslider.value;
        mymixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
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
