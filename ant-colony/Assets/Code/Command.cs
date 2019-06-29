using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Command
{
    public enum Type
    {
        Move,
        ShowDialogue, // DialogueType
        Die,
        LoadScene,
        Spawn,
        Win
    }
    public Type CommandType;
    public Dialogue.DialogueType DialogueType;
    public string SceneName;

    public static Command ShowDialogCommand(Dialogue.DialogueType DialogueType)
    {
        Command showDialogCommand = new Command();
        showDialogCommand.CommandType = Command.Type.ShowDialogue;
        showDialogCommand.DialogueType = DialogueType;
        return showDialogCommand;
    }
}