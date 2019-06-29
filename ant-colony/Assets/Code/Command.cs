using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Command
{
    public enum Type
    {
        Move,
        ShowDialog, // DialogType
        Die,
        LoadScene,
        Spawn,
        Win
    }
    public Type CommandType;
    public DialogType DialogType;
    public string SceneName;

    public static Command ShowDialogCommand(DialogType dialogType)
    {
        Command showDialogCommand = new Command();
        showDialogCommand.CommandType = Command.Type.ShowDialog;
        showDialogCommand.DialogType = dialogType;
        return showDialogCommand;
    }
}