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
        //Man skapar en array som håller sig till FIFO regeln
        sentences = new Queue<string>();
        //nameText = FindObjectOfType<TextMeshProUGUI>();
        //DialogueText = FindObjectOfType<TextMeshProUGUI>();
        
    }
    public void StartDialogue ( Dialogue dialogue)
    {
        //Sätter en panel aktiv - erwin 
        panel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Startar konversation med " + dialogue.name);
        nameText.text = dialogue.name;
        inconversation = true; 
        sentences.Clear();
        
        //skapar en foreach som går igenom varje mening
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextScentence();
    }
    public void DisplayNextScentence()
    {
        //om det finns 0 menningar kvar så slutar dialågen.
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
    //stänger av panelen när konversationen är över.
    void EndDialogue()
    {
        Debug.Log("Slut på konversationen.");
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

}
