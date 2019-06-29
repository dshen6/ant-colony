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
        LoadScene,
        Spawn,
        Win
    }
    public Type CommandType;
    public DialogueNodeAsset.DialogueType DialogType;
    public string SceneName;

    // public static Command StartDialogCommand(DialogueNodeAsset dialogueNodeAsset)
    // {
    //     Command showDialogCommand = new Command();
    //     showDialogCommand.CommandType = Command.Type.StartDialogue;
    //     showDialogCommand.DialogueNodeAsset = dialogueNodeAsset;
    //     return showDialogCommand;
    // }
}