using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog Node")]
public class DialogueNodeAsset : ScriptableObject
{
    public enum DialogueType {
        Spawn,
        Die,
        Midrun,
        AtFork,
        Love,
        Bio,
    }

    // List of commands executed after this node is finished
    public List<Command> commands;

    [TextArea(3, 5)]
    public string[] sentences;
}
