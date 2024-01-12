
using UnityEngine;

public class Audiomaneger : MonoBehaviour
{
    [Header("----------AudioSource----------")]
    [SerializeField] AudioSource musicsource;
    [SerializeField] AudioSource SFXsource;

    [Header("----------AudioSource----------")]
    public AudioClip background;
    private void Start()
    {
        musicsource.clip = background;
        musicsource.Play();
    }
}
