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

    private Queue<string> sentenceQueue;

    private string CurrentSentence;

    public bool IsSpeaking {get; private set;}

    public DialogueNodeAsset.DialogueType? CurrentDialogueType { get; private set;}

    TextMeshProUGUI dialogueText;
    TextMeshProUGUI spacebarHintText;
    DialogueNodeAsset asset;

    void Awake() {
         if (_instance == null){
            _instance = this;
        }
        dialogueText = GameObject.FindGameObjectWithTag("DialogueText").GetComponent<TextMeshProUGUI>();
        spacebarHintText = GameObject.FindGameObjectWithTag("SpacebarHintText").GetComponent<TextMeshProUGUI>();
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
        CurrentDialogueType = DialogueType;
        AdjustTextSizeForDialogueType((DialogueNodeAsset.DialogueType) CurrentDialogueType);
        spacebarHintText.enabled = IsCurrentDialogueBioOrDeath();
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

        CurrentSentence = sentenceQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(CurrentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        IsSpeaking = CurrentDialogueType != DialogueNodeAsset.DialogueType.Bio;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        IsSpeaking = CurrentSentence.Length != dialogueText.text.Length;
    }

    public void Confirm() {
        if (CurrentSentence.Length != dialogueText.text.Length) {
            StopAllCoroutines();
            dialogueText.text = CurrentSentence;
            IsSpeaking = false;
        }
        else if (IsCurrentDialogueBioOrDeath()) {
            DisplayNextSentence();
        }
    }

    public bool IsCurrentDialogueBioOrDeath() {
        return CurrentDialogueType == DialogueNodeAsset.DialogueType.Bio || CurrentDialogueType == DialogueNodeAsset.DialogueType.Die;
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
        CurrentDialogueType = null;
        CurrentSentence = null;
        IsSpeaking = false;
        dialogueText.text = "";
        CommandManager.Instance.addCommands(asset.commands, null);
    }

}
