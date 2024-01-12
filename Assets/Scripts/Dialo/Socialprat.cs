using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socialprat : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager d;
    public void Triggerdialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}
