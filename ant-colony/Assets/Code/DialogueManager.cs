using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;
    public static DialogueManager Instance { get { return _instance; } }

    public Queue<string> sentenceQueue;

    void Awake() {
         if (_instance == null){
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");
        sentenceQueue = new Queue<string>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue(DialogueNodeAsset.DialogueType DialogueType)
    {
        Speaker speaker = PlayerController.Instance.gameObject.GetComponent<Speaker>();

        DialogueNodeAsset asset = speaker.GetDialogueNodeForType(DialogueType);
        Debug.Log("Starting conversation");
        Debug.Log(String.Join(",", asset.sentences));
    }
    /*
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
        Debug.Log(currentSentence);

    }

    public void EndDialogue()
    {
        Debug.Log("we done");
    }
    */
}
