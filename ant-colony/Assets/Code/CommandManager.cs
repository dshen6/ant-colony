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
        switch (command.CommandType)
        {
            case Command.Type.StartDialogue: 
                DialogueManager.Instance.StartDialogue(command.DialogueType);
                break;
            case Command.Type.Spawn:
                GameStateManager.Instance.SpawnPlayer();
                break;
            case Command.Type.Die:
                PlayerController.Instance.Die();
                break;
            default:
                throw new System.Exception("Unimplemented command " + command);
        };
    }
}