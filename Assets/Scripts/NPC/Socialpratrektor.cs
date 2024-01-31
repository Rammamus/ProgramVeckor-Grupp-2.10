using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socialpratrektor : MonoBehaviour
{
    public Dialogue dialogue;
    public AudioClip[] talkSFX;

    public void TriggerREALdialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue, talkSFX);
    }
}
