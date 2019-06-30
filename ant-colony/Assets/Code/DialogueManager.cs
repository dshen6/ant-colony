using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;
    public static DialogueManager Instance { get { return _instance; } }

    public Queue<string> sentenceQueue;
    public Text dialogueText;

    public Animator animator;

    public DialogueNodeAsset asset;

    void Awake() {
         if (_instance == null){
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sentenceQueue = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue(DialogueNodeAsset.DialogueType DialogueType)
    {
        Speaker speaker = PlayerController.Instance.gameObject.GetComponent<Speaker>();
        asset = speaker.GetDialogueNodeForType(DialogueType);
        PlayerController.Instance.NotifyInDialogue(true);
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


    public void EndDialogue()
    {
        PlayerController.Instance.NotifyInDialogue(false);
        CommandManager.Instance.addCommands(asset.commands);
        dialogueText.text = "";
    }

}
