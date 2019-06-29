using System.Collections.Generic;
using UnityEngine;

 public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;

    public static CommandManager Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void addCommands(List<Command> commands) {
        foreach (Command command in commands)
        {
            addCommand(command);
        };
    }

    public void addCommand(Command command) {
        // TOOD: do something with these commands
        switch (command.CommandType)
        {
            case Command.Type.StartDialogue: 
                DialogueManager.Instance.ShowDialogue(command.Dialogue);
                break;
            case Command.Spawn:
                break;
            case Command.Die:
                break;
            default:
                throw new System.Exception("Unimplemented command " + command);
        };
    }
}