using System.Collections.Generic;
using UnityEngine;

public class TriggerCommandOnEnter : MonoBehaviour
{
    const float TRIGGER_THRESHOLD = 1;

    public List<Command> commands = new List<Command>();

    public bool isRepeatableTrigger = true;
    private bool hasTriggered = false;

    public void OnTriggerEnter(Collider other) {
        // If the trigger is not repeatable then we stop here.
        if (hasTriggered && !isRepeatableTrigger) {
            return;
        }
        CommandManager.Instance.addCommands(commands);
        hasTriggered = true;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, TRIGGER_THRESHOLD);
    }
}
