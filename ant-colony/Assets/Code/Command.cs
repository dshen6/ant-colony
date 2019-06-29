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
    public Dialogue Dialogue;
    public string SceneName;

    public static Command StartDialogCommand(Dialogue Dialogue)
    {
        Command showDialogCommand = new Command();
        showDialogCommand.CommandType = Command.Type.StartDialogue;
        showDialogCommand.Dialogue = Dialogue;
        return showDialogCommand;
    }
}