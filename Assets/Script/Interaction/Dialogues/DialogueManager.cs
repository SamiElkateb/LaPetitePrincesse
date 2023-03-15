using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/*
 * This script came from Brackeys tutorial on YouTube:
 * https://www.youtube.com/watch?v=_nRzoTzeyxU
 */

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;
    public InteractionPromptUI _interactionPromptUI;

    private void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start conversation with " + dialogue.name);
        foreach (var sentence in dialogue.sentences)
        {
            Debug.Log(sentence);
        }
        nameText.text = dialogue.name;
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        string sentenceBeingDisplayed = "";
        foreach (char letter in sentence.ToCharArray())
        {
            sentenceBeingDisplayed += letter;
            _interactionPromptUI.SetUp(sentenceBeingDisplayed);
            yield return null;
        }
    }

    public void DisplayNextSentence()
    {
        Debug.Log("DISPLAY NEXT SENTENCE");
        if (sentences.Count == 0)
        {
            EndDialogue();
            Debug.Log("Sentences empty  ");
            return;
        }
        
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndDialogue()
    {
        _interactionPromptUI.Close();
        Debug.Log("End of conversation  " + nameText.text);
    }

    // Need to use enter only for the elmental creatures
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }
}
