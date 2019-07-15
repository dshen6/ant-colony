using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Command
{
    public enum Type
    {
        Move,
        StartDialogue, // DialogueType
        Die,
        Spawn,
        Win,
        StartEnemyAnimation
    }
    public Type CommandType;
    public DialogueNodeAsset.DialogueType DialogueType;
}