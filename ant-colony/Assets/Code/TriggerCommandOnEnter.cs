using System.Collections.Generic;
using UnityEngine;

public class TriggerCommandOnEnter : MonoBehaviour
{
    const float TRIGGER_THRESHOLD = 1;

    public List<Command> commands = new List<Command>();
    private GameObject mostRecentTrigger;
    public bool isRepeatableTrigger = true;
    private bool hasTriggered = false;

    public void OnTriggerEnter(Collider other) {
        if (mostRecentTrigger == other.gameObject) {
            return;
        }
        if (hasTriggered && !isRepeatableTrigger) {
            return;
        }
        mostRecentTrigger = other.gameObject;
        CommandManager.Instance.addCommands(commands);
        hasTriggered = true;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, TRIGGER_THRESHOLD);
    }
}
