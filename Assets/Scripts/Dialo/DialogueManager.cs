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
    public GameObject spelare;
    public GameObject flicka;
    public Animator animator;
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
        animator.SetBool("Isopen", true);
        spelare.GetComponent<PlayerMovement>().enabled = false;
        flicka.GetComponent<Pathsbeh>().enabled = false;
        inconversation = true;
        //Time.timeScale = 0f;
        Debug.Log("Startar konversation med " + dialogue.name);
        nameText.text = dialogue.name;
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(0.07f);
        }
    }
    //st�nger av panelen n�r konversationen �r �ver.
    void EndDialogue()
    {
        animator.SetBool("Isopen", false);
        spelare.GetComponent<PlayerMovement>().enabled = true;
        flicka.GetComponent<Pathsbeh>().enabled = true;
        spelare.GetComponent<PlayerCam>().enabled = true;
        Debug.Log("Slut p� konversationen.");
        //Time.timeScale = 1f;
    }

}
