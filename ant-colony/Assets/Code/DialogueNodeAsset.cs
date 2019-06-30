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
    }

    public List<Command> commands;

    [TextArea(3, 5)]
    public string[] sentences;
}
