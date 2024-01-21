using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socialprat : MonoBehaviour
{
    public Dialogue dialogue;
    public AudioClip[] talkSFX;

    public void Triggerdialogue()
    {
       
        
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue, talkSFX);
    }
}
