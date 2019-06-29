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
        switch (command)
        {
            case Command.PlaceHolder1: 
                Debug.Log(Command.PlaceHolder1.ToString());
                break;
            case Command.PlaceHolder2:
                Debug.Log(Command.PlaceHolder2.ToString());
                break;
            case Command.PlaceHolder3:
                Debug.Log(Command.PlaceHolder3.ToString());
                break;
            default:
                throw new System.Exception("Unimplemented command " + command);
        };
    }
}