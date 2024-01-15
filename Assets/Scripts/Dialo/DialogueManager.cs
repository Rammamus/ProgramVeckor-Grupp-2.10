using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    private Queue<string> sentences;
    public bool inconversation = false;
    public GameObject panel;
    void Start()
    {
        //Man skapar en array som h�ller sig till FIFO regeln
        sentences = new Queue<string>();
        //nameText = FindObjectOfType<TextMeshProUGUI>();
        //DialogueText = FindObjectOfType<TextMeshProUGUI>();
        
    }
    public void StartDialogue ( Dialogue dialogue)
    {
        //S�tter en panel aktiv - erwin 
        panel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Startar konversation med " + dialogue.name);
        nameText.text = dialogue.name;
        inconversation = true; 
        sentences.Clear();
        
        //skapar en foreach som g�r igenom varje mening
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextScentence();
    }
    public void DisplayNextScentence()
    {
        //om det finns 0 menningar kvar s� slutar dial�gen.
        if (sentences.Count == 0)
        {
            inconversation = false;
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;   
        //Debug.Log(sentence);
    }
    //st�nger av panelen n�r konversationen �r �ver.
    void EndDialogue()
    {
        Debug.Log("Slut p� konversationen.");
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

}
