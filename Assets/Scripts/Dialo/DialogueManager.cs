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
        sentences = new Queue<string>();
        //nameText = FindObjectOfType<TextMeshProUGUI>();
        //DialogueText = FindObjectOfType<TextMeshProUGUI>();
    }
    public void StartDialogue ( Dialogue dialogue)
    {
        panel.SetActive(true);
        Debug.Log("Startar konversation med " + dialogue.name);
        nameText.text = dialogue.name;
        inconversation = true; 
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextScentence();
    }
    public void DisplayNextScentence()
    {
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
    void EndDialogue()
    {
        Debug.Log("Slut på konversationen.");
        panel.SetActive(false);
    }

}
