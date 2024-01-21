
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sanity sanity;
    [Header("----------AudioSource----------")]
    [SerializeField] AudioSource musicsource;
    [SerializeField] AudioSource SFXsource;

    [Header("----------AudioSource----------")]
    public AudioClip background;
    public AudioClip knapptryck;
    public AudioClip ficklampa;
    public AudioClip anndasstarkt;
    public AudioClip anndasstraktlight;
    public AudioClip hummfixljud;
    public AudioClip logsamflickadod;
    public AudioClip litenflickagrubel1;
    public AudioClip litenflickagrubbel2;
    public AudioClip magnusgrubbel1;
    public AudioClip magnusgrubbel2;
    public AudioClip melvingrubbel1;
    public AudioClip melvingrubbel2;
    public AudioClip snabbflickadod;
    public AudioClip svaljaljud;
    public AudioClip tonorsgrubbel1;
    public AudioClip tonorsgrubbel2;
    public AudioClip uhmacuttuygrubbel1;
    public AudioClip uhmacuttlygrubbel2;

    private void Start()
    {
       
    }

    public void Update()
    {
        if(sanity.insanePercentage >= 0.5 && !musicsource.isPlaying)
        {
            
            musicsource.Play();
        } else if (sanity.insanePercentage < 0.5f)
        {
            musicsource.Stop();
        }
            

        
    }
    

    public void playMusic()
    {
        musicsource.clip = background;
        musicsource.Play();
    }
}
      