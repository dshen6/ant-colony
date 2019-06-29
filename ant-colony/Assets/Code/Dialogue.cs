using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public enum DialogueType {
        Spawn,
        Die,
        Midrun,
        AtFork,
        Love,
    }

    public DialogueType dialogueType;

    [TextArea(3, 5)]
    public string[] sentences;
}
