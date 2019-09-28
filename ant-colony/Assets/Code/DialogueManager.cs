using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;
    public static DialogueManager Instance { get { return _instance; } }

    public Queue<string> sentenceQueue;

    public bool IsCurrentlyInDialogue { get; private set; }
    TextMeshProUGUI dialogueText;
    DialogueNodeAsset asset;

    void Awake() {
         if (_instance == null){
            _instance = this;
        }
        dialogueText = FindObjectOfType<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        sentenceQueue = new Queue<string>();
    }

    public void StartDialogue(DialogueNodeAsset.DialogueType DialogueType)
    {
        Speaker speaker = PlayerController.Instance.gameObject.GetComponent<Speaker>();
        asset = speaker.GetDialogueNodeForType(DialogueType);
        AdjustTextSizeForDialogueType(DialogueType);
        if (DialogueType != DialogueNodeAsset.DialogueType.Bio) {
            IsCurrentlyInDialogue = true;
        }
        sentenceQueue.Clear();

        foreach (string sentence in asset.sentences)
        {
            sentenceQueue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentSentence = sentenceQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void AdjustTextSizeForDialogueType(DialogueNodeAsset.DialogueType DialogueType) {
        if (DialogueType == DialogueNodeAsset.DialogueType.Bio) {
            dialogueText.fontSize = 24;
        } else {
            dialogueText.fontSize = 32;
        }
    }


    public void EndDialogue()
    {
        IsCurrentlyInDialogue = false;
        dialogueText.text = "";
        CommandManager.Instance.addCommands(asset.commands, null);
    }

}
